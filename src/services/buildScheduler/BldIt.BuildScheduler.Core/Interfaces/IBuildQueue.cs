namespace BldIt.BuildScheduler.Core.Interfaces;

public interface IBuildQueue
{
    void QueueBuild(Func<CancellationToken, Task> task);
    Task<Func<CancellationToken, Task>> DequeueBuildAsync(CancellationToken cancellationToken);
}