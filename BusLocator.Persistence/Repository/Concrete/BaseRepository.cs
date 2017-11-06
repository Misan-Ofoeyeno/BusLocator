using BusLocator.Persistence.Context;
using BusLocator.Persistence.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusLocator.Persistence.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected BusLocatorContext dbContext;
        protected readonly IDbSet<T> _dbset;

        public BaseRepository(BusLocatorContext context)
        {
            dbContext = context;
            _dbset = context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Any(predicate);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.AnyAsync(predicate);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Edit(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public async Task<IQueryable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => _dbset.Where(predicate));
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbset.FirstOrDefault(predicate);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable<T>();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Count(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.CountAsync(predicate);
        }
    }
}
