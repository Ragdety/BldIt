using System.Linq.Expressions;

namespace BldIt.Models.Interfaces
{
    public interface IGenericRepo<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object? id);
        Task<T?> AddAsync(T entity);
        Task<bool> DeleteAsync(object id);
        Task<bool>UpdateAsync(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(object id);
    }
}