using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Core.Models;

namespace BldIt.Jobs.Core.Repos
{
    public interface IJobsRepo : IRepository<Job, Guid>
    {
        Task<Job?> GetByNameAsync(Guid projectId, string jobName);
        Task<bool> ExistsAsync(Guid projectId, string jobName);
    }
}