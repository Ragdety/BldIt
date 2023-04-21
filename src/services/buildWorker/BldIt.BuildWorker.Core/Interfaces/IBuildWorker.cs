using BldIt.BuildScheduler.Contracts.Contracts;

namespace BldIt.BuildWorker.Core.Interfaces;

public interface IBuildWorker
{
    public bool IsWorking { get; set; }
    public Guid WorkingBuildId { get; set; }
    public int WorkingBuildNumber { get; set; }
    public Guid WorkingJobId { get; set; }
    
    Task StartBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken);
    Task CancelBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken);
    Task RestartBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken);
}