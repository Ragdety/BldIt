using BldIt.BuildScheduler.Contracts.Contracts;
using BldIt.BuildWorker.Core.Interfaces;
using BldIt.BuildWorker.Core.Services;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers;

public class BuildStartConsumer : IConsumer<StartBuildRequest>
{
    private readonly ILogger<BuildStartConsumer> _logger;
    private readonly IBuildWorkerManager _buildWorkerManager;
    private readonly StartBuildRequestQueue _buildQueue;

    public BuildStartConsumer(
        ILogger<BuildStartConsumer> logger, 
        IBuildWorkerManager buildWorkerManager, 
        StartBuildRequestQueue buildQueue)
    {
        _logger = logger;
        _buildWorkerManager = buildWorkerManager;
        _buildQueue = buildQueue;
    }
    
    public async Task Consume(ConsumeContext<StartBuildRequest> context)
    {
        var message = context.Message;
        
        _logger.LogInformation("Attempting to start build {Request}", message);

        var addedWorker = await _buildWorkerManager.TryAddActiveWorkerAsync(message);
        
        //If it was successfully added, start the build
        if (addedWorker)
        {
            var worker = _buildWorkerManager.GetActiveWorker(message.BuildId);
            await worker.StartBuildAsync(message, CancellationToken.None);
        }
        
        //Otherwise, the build worker manager will send a message that the max capacity has been reached
    }
}