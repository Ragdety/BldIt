using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace BldIt.Api.Shared.MongoDb;

public static class Extensions
{
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

        services.AddSingleton(serviceProvider => 
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
            var mongoDbSettings = configuration?.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
            var mongoClient = new MongoClient(mongoDbSettings?.ConnectionString);
            return mongoClient.GetDatabase(mongoDbSettings?.Name);
        });

        return services;
    }
    
    public static IServiceCollection AddMongoRepository<T, TKey>(
        this IServiceCollection services, 
        string collectionName) where T : IEntity<TKey>
    {
        services.AddSingleton<IRepository<T, TKey>>(serviceProvider => 
        {
            var database = serviceProvider.GetService<IMongoDatabase>();
            return new MongoRepository<T, TKey>(database ?? 
                                                throw new ArgumentNullException(nameof(database)), collectionName);
        });

        return services;
    }
    
    public static IServiceCollection AddMongoRepository<TRepo, TRepoImp, T, TKey>(
        this IServiceCollection services, 
        string collectionName) 
        where T : IEntity<TKey>
        where TRepo : IRepository<T, TKey>
        where TRepoImp : MongoRepository<T, TKey>, TRepo
    {
        var implementation = new Func<IServiceProvider, object>(serviceProvider =>
        {
            var database = serviceProvider.GetService<IMongoDatabase>();
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            var instance = Activator.CreateInstance(typeof(TRepoImp), database, collectionName);
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            return instance;
        });

        var descriptor = new ServiceDescriptor(typeof(TRepo), implementation, ServiceLifetime.Singleton);
        services.Add(descriptor);
        return services;
    }
}