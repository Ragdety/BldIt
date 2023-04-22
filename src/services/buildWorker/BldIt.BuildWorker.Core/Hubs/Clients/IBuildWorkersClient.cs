using BldIt.BuildWorker.Core.ViewModels;

namespace BldIt.BuildWorker.Core.Hubs.Clients;

public interface IBuildWorkersClient
{
    Task UpdateBuildWorkerAvailability(BuildWorkerViewModel buildWorker);
}