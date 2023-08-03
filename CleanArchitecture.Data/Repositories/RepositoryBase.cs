using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infraestructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        protected readonly StreamerDbContext _context;

        public RepositoryBase(StreamerDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (!string.IsNullOrEmpty(includeString))
            {
                query = query.Include(includeString);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (orderBy is not null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (includes is not null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (orderBy is not null)
            {
                return await orderBy(query).ToListAsync();
            }

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T Entity)
        {
            _context.Set<T>().Add(Entity);
            await _context.SaveChangesAsync();

            return Entity;
        }

        public async Task<T> UpdateAsync(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Entity;
        }

        public async Task DeleteAsync(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            await _context.SaveChangesAsync();
        }

        public void AddEntity(T Entity)
        {
            _context.Set<T>().Add(Entity);
        }

        public void UpdateEntity(T Entity)
        {
            _context.Set<T>().Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
        }

        public void DeleteEntity(T Entity)
        {
            _context.Set<T>().Remove(Entity);
        }
    }
}
