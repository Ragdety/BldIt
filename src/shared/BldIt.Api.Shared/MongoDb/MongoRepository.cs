using System.Linq.Expressions;
using BldIt.Api.Shared.Interfaces;
using MongoDB.Driver;

namespace BldIt.Api.Shared.MongoDb;

public class MongoRepository<T, TKey> : IRepository<T, TKey> where T : IEntity<TKey>
{
    private readonly IMongoCollection<T> _dbCollection;

    private readonly FilterDefinitionBuilder<T> _filterBuilder = Builders<T>.Filter;

    public MongoRepository(IMongoDatabase database, string collectionName)
    {
        _dbCollection = database.GetCollection<T>(collectionName);
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbCollection.Find(filter).ToListAsync();
    }

    public async Task<T> GetAsync(TKey id)
    {
        var filter = _filterBuilder.Eq(entity => entity.Id, id);
        return await _dbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await _dbCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var filter = _filterBuilder.Eq(e => e.Id, entity.Id);
        await _dbCollection.ReplaceOneAsync(filter, entity);
    }

    public async Task RemoveAsync(TKey id)
    {
        var filter = _filterBuilder.Eq(entity => entity.Id, id);
        await _dbCollection.DeleteOneAsync(filter);
    }
}