using BldIt.BuildScheduler.Contracts.Contracts;

namespace BldIt.BuildWorker.Core.Interfaces;

public interface IBuildManager
{
    Task StartBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken);
    Task CancelBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken);
    Task RestartBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken);
}