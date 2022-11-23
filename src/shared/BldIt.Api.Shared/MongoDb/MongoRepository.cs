using System.Linq.Expressions;
using BldIt.Api.Shared.Interfaces;
using MongoDB.Driver;

namespace BldIt.Api.Shared.MongoDb;

public class MongoRepository<T, TKey> : IRepository<T, TKey> where T : IEntity<TKey>
{
    protected readonly IMongoCollection<T> DbCollection;

    protected readonly FilterDefinitionBuilder<T> FilterBuilder = Builders<T>.Filter;

    public MongoRepository(IMongoDatabase database, string collectionName)
    {
        DbCollection = database.GetCollection<T>(collectionName);
    }

    public virtual async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await DbCollection.Find(FilterBuilder.Empty).ToListAsync();
    }

    public virtual async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        return await DbCollection.Find(filter).ToListAsync();
    }

    public virtual async Task<T> GetAsync(TKey id)
    {
        var filter = FilterBuilder.Eq(entity => entity.Id, id);
        return await DbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await DbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public virtual async Task CreateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await DbCollection.InsertOneAsync(entity);
    }

    public virtual async Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var filter = FilterBuilder.Eq(e => e.Id, entity.Id);
        await DbCollection.ReplaceOneAsync(filter, entity);
    }

    public virtual async Task RemoveAsync(TKey id)
    {
        var filter = FilterBuilder.Eq(entity => entity.Id, id);
        await DbCollection.DeleteOneAsync(filter);
    }

    public virtual async Task<bool> ExistsAsync(TKey id)
    {
        var entity = await GetAsync(id);
        if (entity == null)
        {
            return false;
        }
        
        return !entity.Deleted;
    }
}