﻿using System.Text;
using BldIt.Api.Shared;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Services.Storage;
using BldIt.Api.Shared.Services.Storage.Providers;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Contracts.Enums;
using BldIt.Builds.Contracts.Keys;
using BldIt.BuildScheduler.Api.Hubs;
using BldIt.BuildScheduler.Contracts.Contracts;
using BldIt.BuildScheduler.Core.Interfaces;
using BldIt.BuildScheduler.Core.Models;
using BldIt.Shared.Processes;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace BldIt.BuildScheduler.Core.Services;

public class BuildManager : IBuildManager
{
    private readonly ProcessService _processService;
    private readonly IRepository<SchedulerBuildStep, BuildStepKey> _buildStepsRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<BuildManager> _logger;
    private readonly IHubContext<BuildStreamHub> _buildHub;
    private readonly TemporaryFileStorage _temporaryFileStorage;

    public BuildManager(
        ProcessService processService, 
        IRepository<SchedulerBuildStep, BuildStepKey> buildStepsRepository, 
        IPublishEndpoint publishEndpoint, 
        ILogger<BuildManager> logger, 
        IHubContext<BuildStreamHub> buildHub, 
        TemporaryFileStorage temporaryFileStorage)
    {
        _processService = processService;
        _buildStepsRepository = buildStepsRepository;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
        _buildHub = buildHub;
        _temporaryFileStorage = temporaryFileStorage;
    }
    
    public async Task StartBuildAsync(BuildRequest buildRequest, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting build request {BuildRequest}", buildRequest);
        
        await UpdateBuildStatusAsync(buildRequest, BuildStatus.Starting);
        
        // Fetch the build steps based on the buildConfig Id
        var buildSteps = await _buildStepsRepository
            .GetAllAsync(b => b.Id.BuildConfigId == buildRequest.BuildConfigId);

        //Order them by number
        var orderedBuildSteps = buildSteps.OrderBy(k => k.Id.Number);
        
        await UpdateBuildStatusAsync(buildRequest, BuildStatus.Running);
        
        foreach (var buildStep in orderedBuildSteps)
        {
            _logger.LogInformation("Executing build step {BuildStep}", buildStep.Command);
            //Execute the command/script provided by the build step and check its exit code
            try
            {
                var exitCode = await RunBuildStepAsync(buildStep, cancellationToken);
                if (exitCode == 0) continue;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error running build step command \'{BuildStepCommand}\'", buildStep.Command);
            }

            //Otherwise send the failed signal and break out of the function.
            await UpdateBuildResultAsync(buildRequest, BuildResult.Failed);
            
            _logger.LogInformation("Build request {BuildRequest} has failed", buildRequest);
            
            //At this stage, the build manager is done doing its work.
            //We'll let the other services handle the build update by listening to the BuildResultUpdated event.
            return;
        }
        
        //If we reach this point, the build was successful.
        await UpdateBuildResultAsync(buildRequest, BuildResult.Success);
        _logger.LogInformation("Build request {BuildRequest} has succeeded", buildRequest);
    }

    public async Task CancelBuildAsync(BuildRequest buildRequest, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Cancelling build request {BuildRequest}", buildRequest);
        await UpdateBuildStatusAsync(buildRequest, BuildStatus.Aborting);
        
        //TODO: Some Code to cancel the build
        
        await UpdateBuildResultAsync(buildRequest, BuildResult.Canceled);
        
        throw new NotImplementedException();
    }

    public async Task RestartBuildAsync(BuildRequest buildRequest, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Restarting build request {BuildRequest}", buildRequest);
        await CancelBuildAsync(buildRequest, cancellationToken);
        await StartBuildAsync(buildRequest, cancellationToken);
    }
    
    private async Task<int> RunBuildStepAsync(SchedulerBuildStep buildStep, CancellationToken cancellationToken)
    {
        var extension = buildStep.Type switch 
        {
            BuildStepType.Batch => BldItApiConstants.Files.ScriptTypeExtensions.Batch,
            BuildStepType.Shell => BldItApiConstants.Files.ScriptTypeExtensions.Bash,
            _ => throw new ArgumentOutOfRangeException(nameof(buildStep.Type))
        };

        var scriptFilePath = await _temporaryFileStorage.CreateTemporaryScriptFileAsync(buildStep.Command, extension);
        
        
        //var logFile = await _temporaryFileStorage.CreateTemporaryLogFileAsync(string.Empty);
        //await using var fs = new FileStream(logFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        
        _processService.Program = scriptFilePath;
        //_processService.OutputLogPath = logFile;

        //Sends process output to all clients listening (frontend in this case)
        // async Task OutputHandler(string output)
        // {
        //     //await fs.WriteAsync(Encoding.UTF8.GetBytes(output), cancellationToken);
        //     await _buildHub.Clients.All.SendAsync("ReceiveMessage", output, cancellationToken: cancellationToken);
        // }

        void OutputHandler(string? output)
        {
            _logger.LogInformation(output);
        }

        _logger.LogInformation("Executing temporary script file \'{ScriptFilePath}\'", scriptFilePath);
        //return await _processService.RunAsync();
        var exitCode = await _processService.RunAsync(OutputHandler, cancellationToken);
        
        //TODO: Move the scriptFile into its actual save location for this build
        
        _logger.LogInformation("Deleting temporary script file \'{ScriptFilePath}\'", scriptFilePath);
        var script = Path.GetFileName(scriptFilePath);
        _temporaryFileStorage.DeleteTemporaryFile(script);

        return exitCode;
    }
    
    private async Task UpdateBuildStatusAsync(BuildRequest buildRequest, BuildStatus buildStatus)
    {
        await _publishEndpoint.Publish(new BuildStatusUpdated(
            buildRequest.BuildConfigId, 
            buildRequest.BuildNumber, 
            buildStatus));
    }
    
    private async Task UpdateBuildResultAsync(BuildRequest buildRequest, BuildResult buildResult)
    {
        await _publishEndpoint.Publish(new BuildResultUpdated(
            buildRequest.BuildConfigId, 
            buildRequest.BuildNumber, 
            buildResult));
    }
}