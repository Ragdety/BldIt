using BldIt.Api.Shared;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Contracts.Keys;
using BldIt.Builds.Core.Dtos;
using BldIt.Builds.Core.Models;
using BldIt.Builds.Core.Repos;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Builds.Service.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BuildConfigController : ApiController
{
    private readonly UriService _uriService;
    private readonly IBuildConfigRepo _buildsConfigRepo;
    private readonly IRepository<BuildsJob, Guid> _jobsRepo;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRepository<BuildStep, BuildStepKey> _buildStepsRepo;

    public BuildConfigController(
        UriService uriService,
        IBuildConfigRepo buildsConfigRepo,
        IRepository<BuildsJob, Guid> jobsRepo, 
        IPublishEndpoint publishEndpoint, 
        IRepository<BuildStep, BuildStepKey> buildStepsRepo)
    {
        _uriService = uriService;
        _buildsConfigRepo = buildsConfigRepo;
        _jobsRepo = jobsRepo;
        _publishEndpoint = publishEndpoint;
        _buildStepsRepo = buildStepsRepo;
    }

    [HttpPost(Routes.BuildConfigs.Post)]
    public async Task<IActionResult> CreateBuildConfig(
        [FromRoute] Guid projectId,
        [FromRoute] string jobName)//,
        //[FromBody] CreateBuildConfigDto createJobConfig)
    {
        var buildConfigInstance = _uriService.GetBuildConfigsUri(projectId, jobName).AbsoluteUri;
        var job = await EnsureJobExists(projectId, jobName, buildConfigInstance);
            
        var buildConfig = new BuildConfig
        {
            JobId = job.Id
        };
        
        await _buildsConfigRepo.CreateAsync(buildConfig);
        await _publishEndpoint.Publish(new UpdateLatestBuildConfig(buildConfig.JobId, buildConfig.Id));
        
        var createdUri = _uriService.GetBuildConfigsUri(projectId, jobName).AbsoluteUri;
        return Created(createdUri, buildConfig);
    }
    
    [HttpPost(Routes.BuildConfigs.Get)]
    public async Task<IActionResult> UpdateBuildConfig(
        [FromRoute] Guid projectId,
        [FromRoute] string jobName, 
        [FromRoute] Guid configId,
        [FromBody] UpdateBuildConfigDto updateBuildConfig)
    {
        var buildConfigInstance = _uriService.GetBuildConfigsUri(projectId, jobName).AbsoluteUri;
        var job = await EnsureJobExists(projectId, jobName, buildConfigInstance);
        var buildConfig = await EnsureBuildConfigExists(job.Name, configId, buildConfigInstance);

        //Get All build steps for this build config
        var buildSteps = 
            await _buildStepsRepo.GetAllAsync(s => s.Id.BuildConfigId == configId);

        var lastBuildStepNumber = 1;
        
        //If there are any build steps
        if (buildSteps.Any())
        {
            //Find the last build step number (Maximum)
            var latestBuildStep = buildSteps.MaxBy(s => s.Id.Number);
            lastBuildStepNumber = latestBuildStep!.Id.Number;
        }

        //Loop through each step and create a new build step
        foreach (var step in updateBuildConfig.BuildSteps)
        {
            lastBuildStepNumber++;
            var createdStep = new BuildStep
            {
                Id = new BuildStepKey(lastBuildStepNumber, configId),
                Command = step.Command,
                Type = step.Type
            };
            await _buildStepsRepo.CreateAsync(createdStep);
            await _publishEndpoint.Publish(new BuildStepCreated(createdStep.Id, createdStep.Command, createdStep.Type));
        }
        
        var createdUri = _uriService.GetBuildConfigsUri(projectId, jobName).AbsoluteUri;
        return Created(createdUri, buildConfig);
    }

    [HttpGet(Routes.BuildConfigs.Get)]
    public async Task<IActionResult> GetBuildConfig(
        [FromRoute] Guid projectId,
        [FromRoute] string jobName,
        [FromRoute] Guid configId)
    {
        var buildConfigInstance = _uriService.GetBuildConfigsUri(projectId, jobName).AbsoluteUri;
        var job = await EnsureJobExists(projectId, jobName, buildConfigInstance);
        var buildConfig = await EnsureBuildConfigExists(job.Name, configId, buildConfigInstance);

        if (job.Id != buildConfig.JobId)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                "Build Config does not exist within this job",
                buildConfigInstance,
                _uriService));
        }
        
        var buildSteps = 
            await _buildStepsRepo.GetAllAsync(s => s.Id.BuildConfigId == buildConfig.Id);

        //Map BuildConfig with its BuildSteps appended to it
        var buildConfigDto = new
        {
            buildConfig,
            buildSteps
        };
        
        return Ok(buildConfigDto);
    }
    
    private async Task<BuildsJob> EnsureJobExists(Guid projectId, string jobName, string buildConfigInstance)
    {
        var job = await _jobsRepo.GetAsync(j => j.ProjectId == projectId && j.Name == jobName);
        if (job is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job with name {jobName} not found within project {projectId}", 
                buildConfigInstance, 
                _uriService));
        }

        return job;
    }
    
    private async Task<BuildConfig> EnsureBuildConfigExists(string jobName, Guid buildConfigId, string buildConfigInstance)
    {
        var buildConfig = await _buildsConfigRepo.GetAsync(buildConfigId);
        if (buildConfig is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Build Config {buildConfigId.ToString()} not found within job {jobName}", 
                buildConfigInstance, 
                _uriService));
        }

        return buildConfig;
    }
}