using System;
using System.Collections.Generic;
using System.Linq;

namespace DNPA.Repositories.Models
{
    /// <summary>
    /// Implementation for paged set of entities 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedEntities<T> : IPagedEntities<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public IList<T> Items { get; set; }

        public PagedEntities(int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public PagedEntities(IEnumerable<T> pagedSource, int totalItems, int currentPage, int pageSize)
        {
            TotalItems = totalItems;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            Items = pagedSource.ToList();
        }

        public static PagedEntities<T> ToPagedList(IQueryable<T> queryableSource, int currentPage, int pageSize)
        {
            var totalItems = queryableSource.Count();
            var skip = (currentPage - 1) * pageSize;
            var items = queryableSource.Skip(skip).Take(pageSize).ToList();

            return new PagedEntities<T>(items, totalItems, currentPage, pageSize);
        }

    }

    /// <summary>
    /// Enables converting collections and mapping them
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class PagedEntities<TSource, TResult> : IPagedEntities<TResult>
    {
        public PagedEntities(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
            int currentPage, int pageSize)
        {
            var enumerable = source as TSource[] ?? source.ToArray();

            if (0 > currentPage) throw new ArgumentException($"currentPage must be greater than zero");

            if (source is IQueryable<TSource> queryable)
            {
                CurrentPage = currentPage;
                PageSize = pageSize;
                TotalItems = queryable.Count();
                TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);

                var items = queryable.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToArray();

                Items = new List<TResult>(converter(items));
            }
            else
            {
                CurrentPage = currentPage;
                PageSize = pageSize;
                TotalItems = enumerable.Count();
                TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);

                var items = enumerable.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToArray();

                Items = new List<TResult>(converter(items));
            }
        }

        /// <summary>
        /// Enables converting collections
        /// </summary>
        /// <param name="source"></param>
        /// <param name="converter"></param>
        public PagedEntities(IPagedEntities<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            CurrentPage = source.CurrentPage;
            PageSize = source.PageSize;
            TotalItems = source.TotalItems;
            TotalPages = source.TotalPages;

            Items = new List<TResult>(converter(source.Items));
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public IList<TResult> Items { get; set; }
    }

    /// <summary>
    /// Enables Converting collections
    /// </summary>
    public static class PagedEntities
    {
        const int DefaultPageSize = 25;
        public static IPagedEntities<T> Empty<T>()
        {
            return new PagedEntities<T>(1, DefaultPageSize);
        }

        public static IPagedEntities<TResult> From<TResult, TSource>(IPagedEntities<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            return new PagedEntities<TSource, TResult>(source, converter);
        }
    }
}
