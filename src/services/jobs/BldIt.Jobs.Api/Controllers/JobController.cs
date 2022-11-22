using BldIt.Api.Shared;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Errors;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Jobs.Contracts.Dtos;
using BldIt.Jobs.Core.Models;
using BldIt.Jobs.Core.Repos;
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

    public JobController(
        UriService uriService, 
        IJobsRepo jobsRepo,
        ILogger<JobController> logger, 
        IRepository<JobsProject, Guid> projectsRepo)
    {
        _uriService = uriService;
        _jobsRepo = jobsRepo;
        _logger = logger;
        _projectsRepo = projectsRepo;
    }

    [HttpGet(Routes.Jobs.GetName)]
    public async Task<IActionResult> GetByName(
        [FromRoute] Guid projectId, 
        [FromRoute] string jobName)
    {
        //This should query jobs database for Project's table
        //(which will be updated by RabbitMQ messaging)
        var project = await _projectsRepo.GetAsync(projectId);
        if (project == null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Project with id '{projectId}' was not found",
                _uriService.GetJobByNameUri(projectId, jobName).AbsolutePath,
                _uriService));
        }
        
        var job = await _jobsRepo.GetByNameAsync(projectId, jobName);
        if (job == null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job with name '{jobName}' was not found within project id: '{projectId}'",
                _uriService.GetJobByNameUri(projectId, jobName).AbsolutePath,
                _uriService));
        }

        return Ok(job);
    }

    [HttpPost(Routes.Jobs.Post)]
    public async Task<IActionResult> CreateJob(
        [FromBody] JobCreationDto jobToCreate,
        [FromRoute] Guid projectId)
    {
        var project = await _projectsRepo.GetAsync(projectId);
        if (project == null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Project with id '{projectId}' was not found",
                _uriService.GetJobsUri(projectId).AbsolutePath,
                _uriService));
        }
            
        var existingJob = await _jobsRepo.GetByNameAsync(projectId, jobToCreate.JobName);
        if (existingJob != null)
        {
            throw new ProblemDetailsException(new ExistingInstance(
                $"Job with name {jobToCreate.JobName} in project with id '{projectId}' already exists.",
                _uriService.GetJobsUri(projectId).AbsolutePath,
                _uriService));
        }

        var job = new Job
        {
            JobName = jobToCreate.JobName,
            JobDescription = jobToCreate.JobDescription,
            JobType = jobToCreate.JobType,
            UpdatedAt = DateTime.Now,
            JobWorkspacePath = Path.Combine(project.ProjectWorkspacePath, jobToCreate.JobName),
            ProjectId = projectId
        };

        EnsureJobWorkspaceExists(job.JobWorkspacePath);

        await _jobsRepo.CreateAsync(job);

        var locationUri = _uriService.GetJobByNameUri(projectId, job.JobName);
        return Created(locationUri, job);
    }

    private static void EnsureJobWorkspaceExists(string jobWorkspacePath)
    {
        if (!Directory.Exists(jobWorkspacePath))
            Directory.CreateDirectory(jobWorkspacePath);
    }
}