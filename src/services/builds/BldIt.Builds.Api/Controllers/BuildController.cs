using BldIt.Api.Shared;
using BldIt.Api.Shared.Services.Storage;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Responses;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Core.Models;
using BldIt.Builds.Core.Repos;
using BldIt.Shared.Processes;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Builds.Service.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BuildController : ApiController
{
    private readonly IBuildsRepo _buildsRepo;
    private readonly IRepository<BuildsJob, Guid> _jobsRepository;
    private readonly IBuildConfigRepo _buildConfigsRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly UriService _uriService;

    public BuildController(
        IBuildsRepo buildsRepo, 
        IRepository<BuildsJob, Guid> jobsRepository,
        IBuildConfigRepo buildConfigsRepository, 
        IPublishEndpoint publishEndpoint, 
        UriService uriService)
    {
        _buildsRepo = buildsRepo;
        _jobsRepository = jobsRepository;
        _buildConfigsRepository = buildConfigsRepository;
        _publishEndpoint = publishEndpoint;
        _uriService = uriService;
    }
        
    [HttpPost(Routes.Builds.Build)]
    public async Task<IActionResult> Build(
        [FromRoute] Guid projectId, 
        [FromRoute] string jobName,
        CancellationToken cancellationToken)
    {
        var buildInstance = _uriService.GetBuildUri(projectId, jobName).AbsolutePath;
        
        /*
         * Steps:
         * 0. Check if job exists
         * 1. Check if build config exists
         * 2. Publish BuildRequest event (to start build in the background)
         * 3. Create new build with status "Waiting"
         * 4. Publish BuildCreated event
         * 5. Return Accepted response with the uri of the build number
         */
        
        var job = await _jobsRepository.GetAsync(j => j.Name == jobName && j.ProjectId == projectId);
        if (job is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound($"Job with name '{jobName}' was not found", buildInstance, _uriService));
        }

        //This will get the latest build config by default
        var buildConfig = await _buildConfigsRepository.GetAsync(job.Id);
        
        if (buildConfig is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound($"Build config for job '{jobName}' was not found", buildInstance, _uriService));
        }

        var build = new Build
        {
            JobId = job.Id,
            Status = Core.Enums.BuildStatus.Waiting,
            Number = job.LastBuildNumber + 1,
            IsLatest = false //IsLatest will be updated below
        };
        
        await _buildsRepo.CreateAsync(build);
        
        //This will update the old build object to set IsLatest to false and the new build object to set IsLatest to true
        //In the UpdateLatestBuild consumer
        await _publishEndpoint.Publish(new UpdateLatestBuild(build.Id), cancellationToken);
        
        //This will be read by the Jobs service to update the latest build in the respective job
        //And also our scheduler to keep track of the build status
        await _publishEndpoint.Publish(new BuildCreated(build.Id, build.Status.ToString(), build.Number, build.JobId), cancellationToken);

        //We will only send the message to the scheduler here
        await _publishEndpoint.Publish(new BuildRequest(buildConfig.Id), cancellationToken);

        var buildStatusUri = _uriService.GetBuildByNumberUri(projectId, jobName, build.Number);
        return Accepted(buildStatusUri);
    }

    [HttpGet(Routes.Builds.GetBuildByNumber)]
    public async Task<IActionResult> GetBuildByNumber(
        [FromRoute] Guid projectId, 
        [FromRoute] string jobName,
        [FromRoute] int buildNumber)
    {
        var buildInstance = _uriService.GetBuildByNumberUri(projectId, jobName, buildNumber).AbsolutePath;

        var job = await _jobsRepository.GetAsync(j => j.Name == jobName && j.ProjectId == projectId);
        if (job is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound($"Job with name '{jobName}' was not found", buildInstance, _uriService));
        }
        
        var build = await _buildsRepo.GetAsync(b => b.JobId == job.Id && b.Number == buildNumber);

        if (build is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound($"Build '{buildNumber}' was not found", buildInstance, _uriService));
        }
        
        return Ok(build);
    }
}