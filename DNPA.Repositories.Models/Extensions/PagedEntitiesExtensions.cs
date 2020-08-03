using System;
using System.Collections.Generic;
using System.Text;

namespace DNPA.Repositories.Models.Extensions
{
    /// <summary>
    /// Extensions that enable converting EF paged entities
    /// </summary>
    public static class PagedEntitiesExtensions
    {   
        public static IPagedEntities<T> ToPagedList<T>(this IEnumerable<T> source, int totalItems, int currentPage, int pageSize)
        {
            return new PagedEntities<T>(source, totalItems, currentPage, pageSize);
        }

        public static IPagedEntities<TResult> ToPagedList<TSource, TResult>(this IEnumerable<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter, int currentPage, int pageSize)
        {
            return new PagedEntities<TSource, TResult>(source, converter, currentPage, pageSize);
        }     
    }
}
