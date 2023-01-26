using System.Collections.Concurrent;
using BldIt.BuildScheduler.Contracts.Contracts;

namespace BldIt.BuildWorker.Core.Services;

public class StartBuildRequestQueue
{
    private readonly ConcurrentQueue<StartBuildRequest> _builds;

    public StartBuildRequestQueue()
    {
        _builds = new ConcurrentQueue<StartBuildRequest>();
    }
    
    public int Count() => _builds.Count;
    
    public void Queue(StartBuildRequest build)
    {
        _builds.Enqueue(build);
    }
    
    public StartBuildRequest Dequeue()
    {
        _builds.TryDequeue(out var build);

        if (build is null)
        {
            throw new KeyNotFoundException("No builds in queue");
        }
        
        return build;
    }
    
    public bool IsEmpty()
    {
        return _builds.IsEmpty;
    }
}