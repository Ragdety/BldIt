using BldIt.Models.DataModels;

namespace BldIt.Models.Interfaces
{
    public interface IJobRepo : IGenericRepo<Job>
    {
        Task<bool> ExistsAsync(Guid projectId, string jobName);
        Task<Job?> GetByNameAsync(Guid projectId, string jobName);
    }
}