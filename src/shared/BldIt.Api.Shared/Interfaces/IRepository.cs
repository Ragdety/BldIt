using System.Linq.Expressions;

namespace BldIt.Api.Shared.Interfaces;

/// <summary>
/// Interface to represent a generic repository
/// </summary>
/// <typeparam name="T">The type of entity</typeparam>
/// <typeparam name="TKey">The type of primary key of the entity</typeparam>
public interface IRepository<T, in TKey> where T : IEntity<TKey>
{
    Task<IReadOnlyCollection<T>> GetAllAsync();
    Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    Task<T> GetAsync(TKey id);
    Task<T> GetAsync(Expression<Func<T, bool>> filter);
    Task CreateAsync(T item);
    Task UpdateAsync(T item);
    Task RemoveAsync(TKey id);
}