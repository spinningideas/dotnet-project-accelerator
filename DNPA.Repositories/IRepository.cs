using DNPA.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DNPA.Repositories
{
    /// <summary>
    /// Generic repository designed to encapsulate the basic set of data operations 
    /// needed to read, create, update, and delete data within the system
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
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

        /// <summary>
        /// Finds ALL entities in repository having given predicate condition
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="orderBy"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PagedEntities<TEntity>> FindManyOrderedPaged(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            int currentPage,
            int pageSize,
            CancellationToken cancellationToken = default);

        Task<TEntity> CreateAsync(TEntity entity,
            CancellationToken cancellationToken = default);

        Task<RepositoryResponse> UpdateAsync(TEntity entity,
            CancellationToken cancellationToken = default);

        Task<RepositoryResponse> DeleteAsync(TEntity entity,
            CancellationToken cancellationToken = default);
    }
}
