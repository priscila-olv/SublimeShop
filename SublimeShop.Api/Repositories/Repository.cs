using Microsoft.EntityFrameworkCore;
using SublimeShop.Api.Context;
using SublimeShop.Api.IRepositories;
using System.Linq.Expressions;

namespace SublimeShop.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AppDbContext _context = null;
        DbSet<T> _dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public void Post(T entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }
    }
}
