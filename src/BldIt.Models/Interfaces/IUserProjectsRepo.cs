using BldIt.Models.DataModels;

namespace BldIt.Models.Interfaces
{
    public interface IUserProjectsRepo : IGenericRepo<UserProject>
    {
        Task<bool> IsUserInProjectAsync(Guid userId, Guid projectId);
        Task<bool> DoesUserHaveProjectsAsync(Guid userId);
        Task<IEnumerable<Project>?> GetUserProjectsAsync(Guid userId);
        Task<Project?> GetProjectFromUserAsync(Guid userId, string projectName);
    }
}