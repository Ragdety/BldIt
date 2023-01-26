using BldIt.BuildScheduler.Contracts.Contracts;

namespace BldIt.BuildWorker.Core.Interfaces;

public interface IBuildWorkerManager
{
    Task<bool> TryAddActiveWorkerAsync(StartBuildRequest buildRequest);
    Task RemoveActiveWorkerAsync(Guid buildId);
    IBuildWorker GetActiveWorker(Guid buildId);
    bool MaxCapacityReached();
}