using System.Collections.Concurrent;
using BldIt.BuildScheduler.Core.Interfaces;

namespace BldIt.BuildScheduler.Core.Services;

public sealed class BuildQueue : IBuildQueue
{
    private readonly ConcurrentQueue<Func<CancellationToken, Task>> _builds;
    private readonly SemaphoreSlim _signal;

    public BuildQueue()
    {
        _builds = new ConcurrentQueue<Func<CancellationToken, Task>>();
        _signal = new SemaphoreSlim(0);
    }
    
    public void QueueBuild(Func<CancellationToken, Task> task)
    {
        _builds.Enqueue(task);
        _signal.Release();
    }

    public async Task<Func<CancellationToken, Task>> DequeueBuildAsync(CancellationToken cancellationToken)
    {
        await _signal.WaitAsync(cancellationToken);
        
        _builds.TryDequeue(out var build);

        if (build is null)
        {
            throw new ArgumentNullException(nameof(build));
        }
        
        return build;
    }
}