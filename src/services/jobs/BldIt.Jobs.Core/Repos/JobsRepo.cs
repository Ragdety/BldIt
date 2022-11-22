using BldIt.Api.Shared.MongoDb;
using BldIt.Jobs.Core.Models;
using MongoDB.Driver;

namespace BldIt.Jobs.Core.Repos
{
    public class JobsRepo : MongoRepository<Job, Guid>, IJobsRepo
    {
        public JobsRepo(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
            
        }

        public async Task<Job?> GetByNameAsync(Guid projectId, string jobName)
        {
            var filter = 
                FilterBuilder.Eq(x => x.ProjectId, projectId) & FilterBuilder.Eq(x => x.JobName, jobName);

            return await DbCollection.Find(filter).FirstOrDefaultAsync();
        }
        
        public async Task<bool> ExistsAsync(Guid projectId, string jobName)
        {
            var job = await GetByNameAsync(projectId, jobName);
            return job != null;
        }
    }
}