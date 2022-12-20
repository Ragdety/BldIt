using BldIt.Api.Shared.MongoDb;
using BldIt.Builds.Core.Models;
using MongoDB.Driver;

namespace BldIt.Builds.Core.Repos;

public class BuildsRepo : MongoRepository<Build, Guid>, IBuildsRepo
{
    public BuildsRepo(IMongoDatabase database, string collectionName) : base(database, collectionName)
    {
    }

    public async Task<Build> GetLatestAsync()
    {
        return await GetAsync(b => b.IsLatest == true);
    }

    public async Task SetLatestAsync(Guid id)
    {
        var build = await GetAsync(id);
        build.IsLatest = true;
        await UpdateAsync(build);
    }

    public Task<Build> GetByNumberAsync(Guid jobId, int number) => GetAsync(b => b.JobId == jobId && b.Number == number);
}