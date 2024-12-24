using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<bool> ExistAsync(int id);
        bool Exist(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        Task<ICollection<T>> FindListAsync(
            Expression<Func<T, bool>>? predicate,
            params Expression<Func<T, object>>[] includes);
        Task<T?> FindOneAsync(
            Expression<Func<T, bool>>? predicate,
            params Expression<Func<T, object>>[] includes);
    }
}
