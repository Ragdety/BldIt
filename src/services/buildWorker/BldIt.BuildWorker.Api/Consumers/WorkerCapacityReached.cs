using BldIt.BuildWorker.Contracts.Contracts;
using BldIt.BuildWorker.Core.Services;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers;

public class WorkerCapacityReached : IConsumer<BuildWorkerCapacityReached>
{
    private readonly StartBuildRequestQueue _buildQueue;
    private readonly ILogger<WorkerCapacityReached> _logger;

    public WorkerCapacityReached(StartBuildRequestQueue buildQueue, ILogger<WorkerCapacityReached> logger)
    {
        _buildQueue = buildQueue;
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<BuildWorkerCapacityReached> context)
    {
        var message = context.Message;
        
        //This will add a new request to the waiting queue
        _buildQueue.Queue(message.BuildRequest);
        _logger.LogInformation("Builds in worker queue: {Count}", _buildQueue.Count());

        return Task.CompletedTask;
    }
}