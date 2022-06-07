using System.Threading.Tasks;
using BldIt.Models.Abstractions;

namespace BldIt.Models.Interfaces
{
    public interface IUnitOfWork
    {
        //Future Repos here
        IJobRepo JobRepo { get; }
        Task CompleteAsync();
        void Dispose();
    }
}