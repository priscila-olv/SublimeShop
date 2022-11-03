using SublimeShop.Api.Entities;
using SublimeShop.Models.DTOs;
using System.Linq;
using System.Linq.Expressions;

namespace SublimeShop.Api.IRepositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(Expression<Func<T, bool>> predicate);
        void Post(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count();
        
    }
}
