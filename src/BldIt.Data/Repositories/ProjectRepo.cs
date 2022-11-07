using BldIt.Models.DataModels;
using BldIt.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BldIt.Data.Repositories
{
    public class ProjectRepo : GenericRepo<Project>, IProjectRepo
    {
        public ProjectRepo(AppIdentityDbContext context) 
            : base(context) { }
        
        public override async Task<bool> UpdateAsync(Project project)
        {
            var existingProj = await GetByIdAsync(project.Id);
            if (existingProj == null) return false;
            Context.Entry(project).State = EntityState.Modified;
            return true;
        }

        public async Task<Project?> GetByNameAsync(string projectName) =>
            await _dbSet
                .Where(p => p.ProjectName == projectName)
                .FirstOrDefaultAsync();

        public async Task<bool> Exists(string projectName) => await GetByNameAsync(projectName) != null;
        
        public async Task<bool> DoesUserHaveProjectsAsync(Guid userId)
        {
            var creatorProject = await _dbSet.Where(p => p.CreatorId == userId).FirstOrDefaultAsync();
            return creatorProject != null;
        }

        public async Task<IEnumerable<Project>?> GetProjectsCreatedByUserAsync(Guid userId)
        {
            if (!await DoesUserHaveProjectsAsync(userId)) return null;
            var projects = await Context.Set<Project>()
                .Where(p => p.CreatorId == userId)
                .ToListAsync();

            return projects;
        }
        
        public async Task<bool> IsUserOwnerOfProject(Guid userId, Guid projectId)
        {
            var project = await GetByIdAsync(projectId);
            if (project == null) return false;
            return project.CreatorId == userId;
        }
        
        public Task<bool> IsUserInProjectAsync(Guid userId, Guid projectId)
        {
            throw new NotSupportedException("Not suppoerted yet.");
        }
    }
}