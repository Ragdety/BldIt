using BldIt.BuildScheduler.Contracts.Contracts;

namespace BldIt.BuildWorker.Core.Interfaces;

public interface IBuildWorker
{
    Task StartBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken);
    Task CancelBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken);
    Task RestartBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken);
}