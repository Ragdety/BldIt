﻿using BldIt.BuildScheduler.Contracts.Contracts;
using BldIt.BuildWorker.Core.Interfaces;
using BldIt.BuildWorker.Core.Services;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers;

public class BuildStartConsumer : IConsumer<StartBuildRequest>
{
    private readonly ILogger<BuildStartConsumer> _logger;
    private readonly IBuildWorkerManager _buildWorkerManager;

    public BuildStartConsumer(
        ILogger<BuildStartConsumer> logger, 
        IBuildWorkerManager buildWorkerManager)
    {
        _logger = logger;
        _buildWorkerManager = buildWorkerManager;
    }
    
    public async Task Consume(ConsumeContext<StartBuildRequest> context)
    {
        var message = context.Message;
        
        _logger.LogInformation("Attempting to start build {Request}", message);

        //The build worker manager will send a message that the max capacity has been reached
        var addedWorker = await _buildWorkerManager.TryAddActiveWorkerAsync(message);

        if (!addedWorker) return;

        //If it was successfully added, start the build
        var worker = _buildWorkerManager.GetActiveWorker(message.BuildId);
        
        await worker.StartBuildAsync(message, CancellationToken.None);
        
    }
}