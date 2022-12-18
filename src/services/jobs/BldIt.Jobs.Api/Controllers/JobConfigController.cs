using BldIt.Api.Shared;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Jobs.Contracts.Contracts;
using BldIt.Jobs.Core.Dtos;
using BldIt.Jobs.Core.Models;
using BldIt.Jobs.Core.Repos;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Jobs.Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class JobConfigController : ApiController
{
    private readonly IJobsRepo _jobsRepo;
    private readonly UriService _uriService;
    private readonly IRepository<JobConfig, Guid> _jobConfigRepo;
    private readonly IPublishEndpoint _publishEndpoint;

    public JobConfigController(
        IJobsRepo jobsRepo, 
        UriService uriService, 
        IRepository<JobConfig, Guid> jobConfigRepo, 
        IPublishEndpoint publishEndpoint)
    {
        _jobsRepo = jobsRepo;
        _uriService = uriService;
        _jobConfigRepo = jobConfigRepo;
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost(Routes.JobConfigs.Post)]
    public async Task<IActionResult> CreateJobConfig(
        [FromRoute] Guid projectId,
        [FromRoute] string jobName,
        [FromBody] CreateJobConfigDto createJobConfig)
    {
        var jobConfigInstance = _uriService.GetJobConfigsUri(projectId, jobName).AbsoluteUri;
        
        var job = await _jobsRepo.GetAsync(j => j.ProjectId == projectId && j.Name == jobName);
        if (job is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job with name {jobName} not found within project {projectId}", 
                    jobConfigInstance, 
                    _uriService));
        }

        var jobConfig = new FreestyleJobConfig
        {
            JobId = job.Id,
            JobWorkspacePath = createJobConfig.JobWorkspacePath
        };
        
        await _jobConfigRepo.CreateAsync(jobConfig);
        await _publishEndpoint.Publish(new UpdateLatestJobConfig(jobConfig.JobId, jobConfig.Id));
        
        var createdUri = _uriService.GetJobConfigByIdUri(projectId, jobName, jobConfig.Id).AbsoluteUri;
        return Created(createdUri, jobConfig);
    }
    
    private static void EnsureJobWorkspaceExists(string jobWorkspacePath)
    {
        //TODO: Use FileStorage service to check this
        //TODO: (this will take care of weather the file system is local or an S3 bucket)
        if (!Directory.Exists(jobWorkspacePath))
            Directory.CreateDirectory(jobWorkspacePath);
    }
}