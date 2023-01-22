using BldIt.Builds.Contracts.Contracts;

namespace BldIt.BuildScheduler.Core.Interfaces;

public interface IBuildManager
{
    Task StartBuildAsync(BuildRequest buildRequest, CancellationToken cancellationToken);
    Task CancelBuildAsync(BuildRequest buildRequest, CancellationToken cancellationToken);
    Task RestartBuildAsync(BuildRequest buildRequest, CancellationToken cancellationToken);
}