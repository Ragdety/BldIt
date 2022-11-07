using BldIt.Models.DataModels;

namespace BldIt.Models.Interfaces
{
    public interface IProjectRepo : IGenericRepo<Project>
    {
        Task<Project?> GetByNameAsync(string projectName);
        Task<bool> DoesUserHaveProjectsAsync(Guid userId);
        Task<IEnumerable<Project>?> GetProjectsCreatedByUserAsync(Guid userId);
        Task<bool> IsUserInProjectAsync(Guid userId, Guid projectId);
        Task<bool> IsUserOwnerOfProject(Guid userId, Guid projectId);
    }
}