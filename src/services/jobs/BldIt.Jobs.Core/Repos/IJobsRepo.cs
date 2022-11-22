using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Core.Models;

namespace BldIt.Jobs.Core.Repos
{
    public interface IJobsRepo : IRepository<Job, Guid>
    {
        Task<bool> ExistsAsync(Guid projectId, string jobName);
        Task<Job?> GetByNameAsync(Guid projectId, string jobName);
    }
}