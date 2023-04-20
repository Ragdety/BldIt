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
public class JobController : ApiController
{
    private readonly UriService _uriService;
    private readonly ILogger<JobController> _logger;
    private readonly IJobsRepo _jobsRepo;
    private readonly IRepository<JobsProject, Guid> _projectsRepo;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IRepository<JobConfig, Guid> _jobConfigRepo;
    private readonly IRepository<JobsProject, Guid> _jobsProjectRepo;

    public JobController(
        UriService uriService, 
        IJobsRepo jobsRepo,
        ILogger<JobController> logger, 
        IRepository<JobsProject, Guid> projectsRepo, 
        IPublishEndpoint publishEndpoint, 
        IRepository<JobConfig, Guid> jobConfigRepo, 
        IRepository<JobsProject, Guid> jobsProjectRepo)
    {
        _uriService = uriService;
        _jobsRepo = jobsRepo;
        _logger = logger;
        _projectsRepo = projectsRepo;
        _publishEndpoint = publishEndpoint;
        _jobConfigRepo = jobConfigRepo;
        _jobsProjectRepo = jobsProjectRepo;
    }
    
    [HttpGet(Routes.Jobs.GetAll)]
    public async Task<IActionResult> GetAll([FromRoute] Guid projectId)
    {
        var jobsInstance = _uriService.GetJobsUri(projectId).AbsolutePath;
        
        var project = await _projectsRepo.GetAsync(projectId);
        if (project == null || project.Deleted)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Project with id '{projectId}' was not found", jobsInstance, _uriService));
        }
        
        var jobs = await _jobsRepo.GetAllAsync(
            j => j.ProjectId == projectId && !j.Deleted);
        return Ok(jobs);
    }

    [HttpGet(Routes.Jobs.GetName)]
    public async Task<IActionResult> GetByName(
        [FromRoute] Guid projectId, 
        [FromRoute] string jobName)
    {
        var jobInstance = _uriService.GetJobByNameUri(projectId, jobName).AbsolutePath;
        
        //This should query jobs database for Project's table
        //(which will be updated by RabbitMQ messaging)
        var project = await _projectsRepo.GetAsync(projectId);
        if (project == null || project.Deleted)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Project with id '{projectId}' was not found", jobInstance, _uriService));
        }
        
        var job = await _jobsRepo.GetByNameAsync(projectId, jobName);
        if (job == null || job.Deleted)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job with name '{jobName}' was not found within project: '{projectId}'", jobInstance, _uriService));
        }

        return Ok(job);
    }
    
    [HttpGet("/api/v1/jobs/{jobId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid jobId)
    {
        const string jobInstance = "/api/v1/jobs/{jobId}";

        var job = await _jobsRepo.GetAsync(jobId);
        if (job == null || job.Deleted)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job with id '{jobId}' was not found", jobInstance, _uriService));
        }

        return Ok(job);
    }
    
    [HttpPut(Routes.Jobs.GetName)]
    public async Task<IActionResult> UpdateJob(
        [FromBody] JobUpdateDto jobToUpdate,
        [FromRoute] Guid projectId,
        [FromRoute] string jobName)
    {
        var jobInstance = _uriService.GetJobByNameUri(projectId, jobName).AbsolutePath;
        
        var project = await _projectsRepo.GetAsync(projectId);
        if (project == null || project.Deleted)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Project with id '{projectId}' was not found", jobInstance, _uriService));
        }
        
        var job = await _jobsRepo.GetByNameAsync(projectId, jobName);
        if (job == null || job.Deleted)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job with name '{jobName}' was not found within project: '{projectId}'", jobInstance, _uriService));
        }

        job.Name = jobToUpdate.JobName;
        job.Description = jobToUpdate.JobDescription;
        
        await _jobsRepo.UpdateAsync(job);
        await _publishEndpoint.Publish(new JobUpdated(job.Id, job.Name));
        
        return Ok(job);
    }
    
    [HttpDelete(Routes.Jobs.GetName)]
    public async Task<IActionResult> DeleteJob(
        [FromRoute] Guid projectId,
        [FromRoute] string jobName)
    {
        var jobInstance = _uriService.GetJobByNameUri(projectId, jobName).AbsolutePath;
        
        var project = await _projectsRepo.GetAsync(projectId);
        if (project == null || project.Deleted)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Project with id '{projectId}' was not found", jobInstance, _uriService));
        }
        
        var job = await _jobsRepo.GetByNameAsync(projectId, jobName);
        if (job == null || job.Deleted)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job with name '{jobName}' was not found within project: '{projectId}'", jobInstance, _uriService));
        }

        job.Deleted = true;
        await _jobsRepo.UpdateAsync(job);
        
        //TODO: Delete all job configs, and everything related to this job, and in other microservices as well
        //await _publishEndpoint.Publish(new JobDeleted(job.Id, job.Name));
        
        return NoContent();
    }

    [HttpPost(Routes.Jobs.Post)]
    public async Task<IActionResult> CreateJob(
        [FromBody] JobCreationDto jobToCreate,
        [FromRoute] Guid projectId)
    {
        var jobCreationInstance = _uriService.GetJobsUri(projectId).AbsolutePath;
        
        var project = await _projectsRepo.GetAsync(projectId);
        if (project == null || project.Deleted)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Project with id '{projectId}' was not found",
                jobCreationInstance,
                _uriService));
        }

        var exists = await _jobsRepo.ExistsAsync(projectId, jobToCreate.JobName);
        if (exists)
        {
            throw new ProblemDetailsException(new ExistingInstance(
                $"Job with name {jobToCreate.JobName} in project with '{projectId}' already exists.",
                jobCreationInstance,
                _uriService));
        }

        var job = new Job
        {
            Name = jobToCreate.JobName,
            Description = jobToCreate.JobDescription,
            Type = jobToCreate.JobType,
            ProjectId = projectId
        };

        await _jobsRepo.CreateAsync(job);
        await _publishEndpoint.Publish(new JobCreated
        (
            job.Id,
            job.Name,
            job.ProjectId
        ));
        
        //Create job config (Doing it here now instead of the controller, to make frontend calls easier
        var jobProject = await _jobsProjectRepo.GetAsync(projectId);
        
        var jobWorkspace = Path.Combine(jobProject.ProjectWorkspacePath, "jobs", job.Name);

        var jobConfig = new FreestyleJobConfig
        {
            JobId = job.Id,
            JobWorkspacePath = jobWorkspace
        };
        
        await _jobConfigRepo.CreateAsync(jobConfig);
        await _publishEndpoint.Publish(new JobConfigCreated
        (
            jobConfig.Id,
            job.Id,
            jobWorkspace
        ));
        
        //Update the latest job config id
        var jobCreatedFromRepo = await _jobsRepo.GetAsync(job.Id);
        jobCreatedFromRepo.LatestJobConfigId = jobConfig.Id;
        await _jobsRepo.UpdateAsync(jobCreatedFromRepo);
        
        job.LatestJobConfigId = jobConfig.Id;

        var locationUri = _uriService.GetJobByNameUri(projectId, job.Name);
        return Created(locationUri, job);
    }
}