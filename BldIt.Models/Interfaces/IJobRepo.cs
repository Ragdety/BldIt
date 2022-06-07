using System.Threading.Tasks;
using BldIt.Models.DataModels;

namespace BldIt.Models.Interfaces
{
    public interface IJobRepo : IGenericRepo<Job>
    {
        Task<bool> JobExists(string jobName);
    }
}