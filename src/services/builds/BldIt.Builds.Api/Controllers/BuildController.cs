﻿using System.IO.Compression;
using BldIt.Api.Shared;
using BldIt.Api.Shared.Services.Storage;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Responses;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Contracts.Enums;
using BldIt.Builds.Core.Models;
using BldIt.Builds.Core.Repos;
using BldIt.Shared.Processes;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZipArchive = SharpCompress.Archives.Zip.ZipArchive;

namespace BldIt.Builds.Service.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BuildController : ApiController
{
    private readonly IBuildsRepo _buildsRepo;
    private readonly IRepository<BuildsJob, Guid> _jobsRepository;
    private readonly IBuildConfigRepo _buildConfigsRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly UriService _uriService;
    private readonly IRepository<BuildsJobConfig, Guid> _jobConfigsRepository;
    private readonly ILogger<BuildController> _logger;

    public BuildController(
        IBuildsRepo buildsRepo, 
        IRepository<BuildsJob, Guid> jobsRepository,
        IBuildConfigRepo buildConfigsRepository, 
        IPublishEndpoint publishEndpoint, 
        UriService uriService, 
        IRepository<BuildsJobConfig, Guid> jobConfigsRepository, 
        ILogger<BuildController> logger)
    {
        _buildsRepo = buildsRepo;
        _jobsRepository = jobsRepository;
        _buildConfigsRepository = buildConfigsRepository;
        _publishEndpoint = publishEndpoint;
        _uriService = uriService;
        _jobConfigsRepository = jobConfigsRepository;
        _logger = logger;
    }
        
    [HttpPost(Routes.Builds.Build)]
    public async Task<IActionResult> Build(
        [FromRoute] Guid projectId, 
        [FromRoute] string jobName,
        CancellationToken cancellationToken)
    {
        //Cancellation Token here is used to cancel a build that has not been started yet but is in the queue
        
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
        var buildConfig = await _buildConfigsRepository.GetBuildConfigForJobAsync(job.Id);
        
        if (buildConfig is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound($"Build config for job '{jobName}' was not found", buildInstance, _uriService));
        }

        var oldLastBuildNumber = job.LastBuildNumber;

        var build = new Build
        {
            JobId = job.Id,
            Status = BuildStatus.Waiting,
            Number = oldLastBuildNumber + 1,
            IsLatest = true
        };
        
        await _buildsRepo.CreateAsync(build);
        
        //This will update the old build object to set IsLatest to false and the new build object to set IsLatest to true
        //In the UpdateLatestBuild consumer
        await _publishEndpoint.Publish(new UpdateLatestBuild(job.Id, oldLastBuildNumber), cancellationToken);
        
        //This will be read by the Jobs and this service to update the latest build in the respective job
        //Also the worker service so it keeps track of builds created to identify them when running a build
        await _publishEndpoint.Publish(
            new BuildCreated(build.Id, build.Status.ToString(), build.Number, build.JobId), cancellationToken);

        //We will only send the message to the scheduler here requesting a build
        await _publishEndpoint.Publish(new BuildRequest(build.Id, buildConfig.Id, build.Number, build.JobId), cancellationToken);

        var buildStatusUri = _uriService.GetBuildByNumberUri(projectId, jobName, build.Number);
        return Accepted(buildStatusUri, build);
    }

    // public Task<IActionResult> CancelBuild()
    // {
    //     //We will use this endpoint to cancel a build that is already running. Somehow? IDK yet
    //     //TODO: Implement this
    //     throw new NotImplementedException();
    // }

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
    
    [HttpGet("/api/v1/builds/{buildId:guid}")]
    public async Task<IActionResult> GetBuildByNumber([FromRoute] Guid buildId)
    {
        const string buildInstance = "/api/v1/builds/{buildId}";
        
        var build = await _buildsRepo.GetAsync(b => b.Id == buildId);
        if (build is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound($"Build '{buildId}' was not found", buildInstance, _uriService));
        }
        
        return Ok(build);
    }

    [HttpGet(Routes.Builds.GetAll)]
    public async Task<IActionResult> GetAllBuildsForJob([FromRoute] Guid projectId, [FromRoute] string jobName)
    {
        var job = await _jobsRepository.GetAsync(j => j.Name == jobName && j.ProjectId == projectId);
        if (job is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound($"Job with name '{jobName}' was not found", 
                    Routes.Builds.GetAll
                        .Replace("{projectId}", projectId.ToString())
                        .Replace("{jobName}", jobName), 
                    _uriService));
        }
        
        var builds = await _buildsRepo.GetAllAsync(b => b.JobId == job.Id);
        return Ok(builds);
    }
    
    //TODO: Let BldIt admin only see this (retrieves all builds for all jobs)
    [HttpGet("api/v1/builds")]
    public async Task<IActionResult> GetAllBuilds() => Ok(await _buildsRepo.GetAllAsync());
    
    //TODO: Let Project Admin Role only do this
    [HttpDelete(Routes.Builds.GetAll)]
    public async Task<IActionResult> DeleteAllBuildsForJob([FromRoute] Guid projectId, [FromRoute] string jobName)
    {
        var job = await _jobsRepository.GetAsync(j => j.Name == jobName && j.ProjectId == projectId);
        if (job is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound($"Job with name '{jobName}' was not found", 
                    Routes.Builds.GetAll
                        .Replace("{projectId}", projectId.ToString())
                        .Replace("{jobName}", jobName), 
                    _uriService));
        }
        
        var builds = await _buildsRepo.GetAllAsync(b => b.JobId == job.Id);
        foreach (var build in builds)
        {
            await _buildsRepo.RemoveAsync(build.Id);
        }
        
        //This will be read by jobs service so it can update the last build number back to 0
        await _publishEndpoint.Publish(new JobBuildsDeleted(job.Id));
        
        return NoContent();
    }
    
    [HttpGet(Routes.Builds.GetBuildLog)]
    public async Task<IActionResult> GetBuildLogFileContents([FromRoute] Guid projectId, [FromRoute] string jobName, [FromRoute] int buildNumber)
    {
        //var build = await 
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

        if (build.LogFilePath is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound($"Log File Path for Build '{buildNumber}' was not found", buildInstance, _uriService));
        }
        
        var logContent = await System.IO.File.ReadAllTextAsync(build.LogFilePath);
        
        //Parse logContent and return a list of log entries on each new line of the file
        var logEntries = logContent.Split(Environment.NewLine);

        return Ok(new
        {
            LogPath = build.LogFilePath,
            LogContent = logContent,
            LogEntries = logEntries
        });

        // await using var file = new FileStream(build.LogFilePath, FileMode.Open, FileAccess.Read);
        // return File(file, "text/plain");
    }
    
    [HttpGet(Routes.Builds.GetBuildByNumber + "/artifacts")]
    public async Task<IActionResult> GetBuildArtifactsList(
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
        
        var jobConfig = await _jobConfigsRepository.GetAsync(c => c.JobId == job.Id);
        
        var artifactsPath = Path.Combine(jobConfig.JobWorkspacePath,
            "builds",
            buildNumber.ToString(),
            "artifacts");
        
        var zipPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".zip");
        ZipFile.CreateFromDirectory(artifactsPath, zipPath);
        
        var fileBytes = await System.IO.File.ReadAllBytesAsync(zipPath);
        return File(fileBytes, "application/zip", Path.GetFileName(zipPath));
    }

    private List<string> GetFilesRecursive(string directoryPath)
    {
        var fileNames = new List<string>();
        foreach (var filePath in Directory.GetFiles(directoryPath))
        {
            fileNames.Add(Path.GetFileName(filePath));
        }
        foreach (var subdirectoryPath in Directory.GetDirectories(directoryPath))
        {
            fileNames.AddRange(GetFilesRecursive(subdirectoryPath));
        }
        return fileNames;
    }
    
    //Get file paths recursively
    
}