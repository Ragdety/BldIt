using BldIt.Api.Shared.MongoDb;
using BldIt.Projects.Core.Models;
using MongoDB.Driver;

namespace BldIt.Projects.Core.Repos
{
    public class ProjectRepo : MongoRepository<Project, Guid>, IProjectRepo
    {
        public ProjectRepo(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
        }

        public async Task<Project?> GetByNameAsync(string projectName) =>
            await GetAsync(p => p.ProjectName == projectName);

        public async Task<bool> Exists(string projectName) => await GetByNameAsync(projectName) != null;
        
        public async Task<bool> DoesUserHaveProjectsAsync(Guid userId)
        {
            var filter = FilterBuilder.Eq(p => p.CreatorId, userId);
            var creatorProject = await DbCollection.Find(filter).FirstOrDefaultAsync();
            return creatorProject != null;
        }

        public async Task<IEnumerable<Project>?> GetProjectsCreatedByUserAsync(Guid userId)
        {
            if (!await DoesUserHaveProjectsAsync(userId)) return null;
            return await DbCollection.Find(p => p.CreatorId == userId).ToListAsync();
        }
        
        public async Task<bool> IsUserOwnerOfProject(Guid userId, Guid projectId)
        {
            var filter = FilterBuilder.Eq(p => p.Id, projectId);
            var project = await DbCollection.Find(filter).FirstOrDefaultAsync();
            if (project == null) return false;
            return project.CreatorId == userId;
        }
        
        public Task<bool> IsUserInProjectAsync(Guid userId, Guid projectId)
        {
            throw new NotSupportedException("Function not suppoerted yet.");
        }
    }
}