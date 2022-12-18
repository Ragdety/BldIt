using BldIt.Api.Shared.MongoDb;
using BldIt.Builds.Core.Models;
using MongoDB.Driver;

namespace BldIt.Builds.Core.Repos;

public class BuildConfigRepo : MongoRepository<BuildConfig, Guid>, IBuildConfigRepo
{
    public BuildConfigRepo(IMongoDatabase database, string collectionName) : base(database, collectionName)
    {
    }
}