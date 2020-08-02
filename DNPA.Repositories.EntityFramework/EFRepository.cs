using DNPA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DNPA.Repositories.EntityFramework
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DNPADBContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EFRepository(DNPADBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> FindOne(Expression<Func<TEntity, bool>> condition,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(condition);
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<List<TEntity>> FindMany(Expression<Func<TEntity, bool>> condition,
            CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbSet.AsNoTracking().Where(condition).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }
        public async Task<TEntity> CreateAsync(TEntity entity,
            CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(CreateAsync)} entity must not be null");
            }

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<Response> UpdateAsync(TEntity entity,
            CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return new Response(true, "Updated Successfully");
            }
            catch (Exception)
            {
                return new Response(false, $"{nameof(entity)} could not be updated");
            }
        }

        public async Task<Response> DeleteAsync(TEntity entity,
            CancellationToken cancellationToken = default)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }

            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();

                return new Response(true, "Deleted Successfully");
            }
            catch (Exception)
            {
                return new Response(false, $"{nameof(entity)} could not be deleted");
            }
        }
    }
}
