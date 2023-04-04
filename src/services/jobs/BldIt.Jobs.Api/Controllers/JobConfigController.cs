using BldIt.Api.Shared;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Config;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Jobs.Api.Consumers.Jobs;
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
    private readonly IRepository<ScmConfig, Guid> _scmConfigRepo;
    private readonly IRepository<JobsProject, Guid> _jobsProjectRepo;

    public JobConfigController(
        IJobsRepo jobsRepo, 
        UriService uriService, 
        IRepository<JobConfig, Guid> jobConfigRepo, 
        IPublishEndpoint publishEndpoint, 
        IRepository<ScmConfig, Guid> scmConfigRepo, 
        IRepository<JobsProject, Guid> jobsProjectRepo)
    {
        _jobsRepo = jobsRepo;
        _uriService = uriService;
        _jobConfigRepo = jobConfigRepo;
        _publishEndpoint = publishEndpoint;
        _scmConfigRepo = scmConfigRepo;
        _jobsProjectRepo = jobsProjectRepo;
    }

    [HttpPost(Routes.JobConfigs.Post)]
    public async Task<IActionResult> CreateJobConfig(
        [FromRoute] Guid projectId,
        [FromRoute] string jobName)
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
        
        var jobProject = await _jobsProjectRepo.GetAsync(projectId);
        
        var jobWorkspace = Path.Combine(jobProject.ProjectWorkspacePath, "jobs", job.Name);

        var jobConfig = new FreestyleJobConfig
        {
            JobId = job.Id,
            JobWorkspacePath = jobWorkspace
        };
        
        await _jobConfigRepo.CreateAsync(jobConfig);
        await _publishEndpoint.Publish(new UpdateLatestJobConfig(jobConfig.JobId, jobConfig.Id));
        
        var createdUri = _uriService.GetJobConfigByIdUri(projectId, jobName, jobConfig.Id).AbsoluteUri;
        return Created(createdUri, jobConfig);
    }
    
    [HttpGet(Routes.JobConfigs.Get)]
    public async Task<IActionResult> GetJobConfig(
        [FromRoute] Guid projectId,
        [FromRoute] string jobName,
        [FromRoute] Guid configId)
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
        
        var jobConfig = await _jobConfigRepo.GetAsync(j => j.Id == configId);
        if (jobConfig is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job config with id {configId} not found", 
                jobConfigInstance, 
                _uriService));
        }
        
        return Ok(jobConfig);
    }
    
    [HttpPost(Routes.JobConfigs.ScmConfigs.PostScm)]
    public async Task<IActionResult> CreateScmConfig(
        [FromRoute] Guid projectId,
        [FromRoute] string jobName,
        [FromRoute] Guid configId,
        [FromBody] CreateScmConfigDto createScmConfig)
    {
        var scmConfigInstance = _uriService.GetScmConfigsUri(projectId, jobName, configId).AbsoluteUri;

        var job = await _jobsRepo.GetAsync(j => j.ProjectId == projectId && j.Name == jobName);
        if (job is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job with name {jobName} not found within project {projectId}", 
                scmConfigInstance, 
                _uriService));
        }

        var jobConfig = await _jobConfigRepo.GetAsync(j => j.Id == configId);
        if (jobConfig is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job config with id {configId} not found", 
                scmConfigInstance, 
                _uriService));
        }
        
        //No need to check credential id since frontend will let user choose from an existing list of credentials
        //Same with the repo
        var scmConfig = new ScmConfig
        {
            RepoId = createScmConfig.RepoId,
            RepoName = createScmConfig.RepoName,
            RepoUrl = createScmConfig.RepoUrl,
            Branch = createScmConfig.Branch,
            GitHubCredentialId = createScmConfig.GitHubCredentialId,
            JobConfigId = jobConfig.Id,
            JobId = job.Id
        };
        
        await _scmConfigRepo.CreateAsync(scmConfig);
        await _publishEndpoint.Publish(new ScmConfigCreated(scmConfig.Id, 
            scmConfig.RepoId, scmConfig.RepoName, scmConfig.RepoUrl, scmConfig.Branch, 
            scmConfig.GitHubCredentialId, scmConfig.JobConfigId, scmConfig.JobId));
        
        var createdUri = _uriService.GetScmConfigUri(projectId, jobName, jobConfig.Id, scmConfig.Id).AbsoluteUri;
        return Created(createdUri, scmConfig);
    }

    [HttpGet(Routes.JobConfigs.ScmConfigs.GetScm)]
    public async Task<IActionResult> GetScmConfig(
        [FromRoute] Guid projectId,
        [FromRoute] string jobName,
        [FromRoute] Guid configId,
        [FromRoute] Guid scmConfigId)
    {
        var scmConfigInstance = _uriService.GetScmConfigUri(projectId, jobName, configId, scmConfigId).AbsoluteUri;

        var job = await _jobsRepo.GetAsync(j => j.ProjectId == projectId && j.Name == jobName);
        if (job is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job with name {jobName} not found within project {projectId}", 
                scmConfigInstance, 
                _uriService));
        }

        var jobConfig = await _jobConfigRepo.GetAsync(j => j.Id == configId);
        if (jobConfig is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job config with id {configId} not found", 
                scmConfigInstance, 
                _uriService));
        }
        
        var scmConfig = await _scmConfigRepo.GetAsync(s => s.Id == scmConfigId);
        if (scmConfig is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Scm config with id {scmConfigId} not found", 
                scmConfigInstance, 
                _uriService));
        }
        
        return Ok(scmConfig);
    }
    
    [HttpPut(Routes.JobConfigs.ScmConfigs.PutScm)]
    public async Task<IActionResult> UpdateScmConfig(
        [FromRoute] Guid projectId,
        [FromRoute] string jobName,
        [FromRoute] Guid configId,
        [FromRoute] Guid scmConfigId,
        [FromBody] UpdateScmConfigDto updateScmConfig)
    {
        var scmConfigInstance = _uriService.GetScmConfigUri(projectId, jobName, configId, scmConfigId).AbsoluteUri;

        var job = await _jobsRepo.GetAsync(j => j.ProjectId == projectId && j.Name == jobName);
        if (job is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job with name {jobName} not found within project {projectId}", 
                scmConfigInstance, 
                _uriService));
        }

        var jobConfig = await _jobConfigRepo.GetAsync(j => j.Id == configId);
        if (jobConfig is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Job config with id {configId} not found", 
                scmConfigInstance, 
                _uriService));
        }
        
        var scmConfig = await _scmConfigRepo.GetAsync(s => s.Id == scmConfigId);
        if (scmConfig is null)
        {
            throw new ProblemDetailsException(new InstanceNotFound(
                $"Scm config with id {scmConfigId} not found", 
                scmConfigInstance, 
                _uriService));
        }
        
        scmConfig.RepoId = updateScmConfig.RepoId;
        scmConfig.RepoName = updateScmConfig.RepoName;
        scmConfig.RepoUrl = updateScmConfig.RepoUrl;
        scmConfig.Branch = updateScmConfig.Branch;
        scmConfig.GitHubCredentialId = updateScmConfig.GitHubCredentialId;
        
        await _scmConfigRepo.UpdateAsync(scmConfig);
        await _publishEndpoint.Publish(new ScmConfigUpdated(scmConfig.Id, 
            scmConfig.RepoId, scmConfig.RepoName, scmConfig.RepoUrl, scmConfig.Branch, 
            scmConfig.GitHubCredentialId));
        
        return Ok(scmConfig);
    }


    private static void EnsureJobWorkspaceExists(string jobWorkspacePath)
    {
        //TODO: Use FileStorage service to check this
        //TODO: (this will take care of weather the file system is local or an S3 bucket)
        if (!Directory.Exists(jobWorkspacePath))
            Directory.CreateDirectory(jobWorkspacePath);
    }
}