using BldIt.BuildWorker.Contracts.Contracts;
using BldIt.BuildWorker.Core.Interfaces;
using BldIt.BuildWorker.Core.Services;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers;

public class WorkerCapacityAvailable : IConsumer<BuildWorkerCapacityAvailable>
{
    private readonly StartBuildRequestQueue _buildQueue;
    private readonly IBuildWorkerManager _buildWorkerManager;
    private readonly ILogger<WorkerCapacityAvailable> _logger;
    
    public WorkerCapacityAvailable(
        StartBuildRequestQueue buildQueue, 
        IBuildWorkerManager buildWorkerManager, 
        ILogger<WorkerCapacityAvailable> logger)
    {
        _buildQueue = buildQueue;
        _buildWorkerManager = buildWorkerManager;
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<BuildWorkerCapacityAvailable> context)
    {
        //Do nothing if no builds are in the queue
        if (_buildQueue.IsEmpty()) return;
        
        var build = _buildQueue.Dequeue();
        _logger.LogInformation("Dequeued build request {Build}.", build);
        
        var added = await _buildWorkerManager.TryAddActiveWorkerAsync(build);
        
        if (added)
        {
            var worker = _buildWorkerManager.GetActiveWorker(build.BuildId);
            await worker.StartBuildAsync(build, CancellationToken.None);
        }
    }
}