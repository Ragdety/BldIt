using System;
using System.Threading.Tasks;

namespace BldIt.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepo ProjectRepo { get; }
        IJobRepo JobRepo { get; }
        Task CompleteAsync();
        new void Dispose();
    }
}