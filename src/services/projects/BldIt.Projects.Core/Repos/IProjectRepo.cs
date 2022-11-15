using BldIt.Api.Shared.Interfaces;
using BldIt.Projects.Core.Models;

namespace BldIt.Projects.Core.Repos
{
    public interface IProjectRepo : IRepository<Project, Guid>
    {
        Task<Project?> GetByNameAsync(string projectName);
        Task<bool> DoesUserHaveProjectsAsync(Guid userId);
        Task<IEnumerable<Project>?> GetProjectsCreatedByUserAsync(Guid userId);
        Task<bool> IsUserInProjectAsync(Guid userId, Guid projectId);
        Task<bool> IsUserOwnerOfProject(Guid userId, Guid projectId);
    }
}