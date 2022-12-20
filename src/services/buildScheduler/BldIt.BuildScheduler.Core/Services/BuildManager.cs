using BldIt.Api.Shared.Interfaces;
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

    public BuildManager(
        ProcessService processService, 
        IRepository<SchedulerBuildStep, BuildStepKey> buildStepsRepository, 
        IPublishEndpoint publishEndpoint, 
        ILogger<BuildManager> logger, 
        IHubContext<BuildStreamHub> buildHub)
    {
        _processService = processService;
        _buildStepsRepository = buildStepsRepository;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
        _buildHub = buildHub;
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
            //Execute the command/script provided by the build step and check its exit code
            var exitCode = await RunBuildStepAsync(buildStep, cancellationToken);
            if (exitCode == 0) continue;
            
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
        await UpdateBuildStatusAsync(buildRequest, BuildStatus.Aborting);
        
        //TODO: Some Code to cancel the build
        
        await UpdateBuildResultAsync(buildRequest, BuildResult.Canceled);
        
        throw new NotImplementedException();
    }

    public Task RestartBuildAsync(BuildRequest buildRequest, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    private async Task<int> RunBuildStepAsync(SchedulerBuildStep buildStep, CancellationToken cancellationToken)
    {
        //TODO: Create a file for the buildStep.Command
        _processService.Program = buildStep.Command;
        
        //Sends process output to all clients listening (frontend in this case)
        async Task OutputHandler(string output)
        {
            await _buildHub.Clients.All.SendAsync("ReceiveMessage", output, cancellationToken: cancellationToken);
        }
        
        return await _processService.RunAsync();
        
        // var savePath = await _temporaryFileStorage.CreateTemporaryFile(
        //     job.BuildSteps.First().Command, 
        //     buildConfig.BuildStepType);
        //     
        // _processService.Program = savePath;
        // _processService.WorkingDirectory = job.JobWorkspacePath;
        //
        
        //
        // //Run process created by build-step command giving it the output to send to frontend
        // //This should be a background process/task
        // var exitCode = await _processService.RunAsync((Func<string, Task>) OutputHandler);
        //
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