using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DNPA.Repositories.Models.Extensions
{
    public static class IQueryablePagedEntitiesExtensions
    {
        public static async Task<PagedEntities<T>> ToPagedListAsync<T>(this IQueryable<T> source
            , int currentPage
            , int pageSize,
            CancellationToken cancellationToken = default)
        {
            if (0 > currentPage) throw new ArgumentException($"currentPage: {currentPage}, must be greater than zero");

            var totalItems = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            var items = await source.Skip((currentPage - 1) * pageSize)
                .Take(pageSize).ToListAsync(cancellationToken).ConfigureAwait(false);

            var list = new PagedEntities<T>(items, totalItems, currentPage, pageSize);

            return list;
        }
    }
}
