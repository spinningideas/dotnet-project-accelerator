using DNPA.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DNPA.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {

        /// <summary>
        /// Finds at most ONE entity in repository having given predicate condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<TEntity> FindOne(Expression<Func<TEntity, bool>> condition,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds ALL entities in repository having given predicate condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<List<TEntity>> FindMany(Expression<Func<TEntity, bool>> condition,
            CancellationToken cancellationToken = default);

        Task<TEntity> CreateAsync(TEntity entity,
            CancellationToken cancellationToken = default);

        Task<Response> UpdateAsync(TEntity entity,
            CancellationToken cancellationToken = default);

        Task<Response> DeleteAsync(TEntity entity,
            CancellationToken cancellationToken = default);
    }
}
