using System;
using System.IO;
using System.Threading.Tasks;
using BldIt.Api.Options;
using BldIt.Api.Services;
using BldIt.Models.DataModels;
using BldIt.Models.Exceptions;
using BldIt.Models.Forms;
using BldIt.Models.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BldIt.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class JobController : ApiController
    {
        private readonly UriService _uriService;
        private readonly BldItEnvVariablesSettings _bldItEnvVariablesSettings;
        private readonly ILogger<JobController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public JobController(
            UriService uriService, 
            IUnitOfWork unitOfWork,
            IOptionsMonitor<BldItEnvVariablesSettings> bldItSettingsMonitor,
            ILogger<JobController> logger)
        {
            _uriService = uriService;
            _unitOfWork = unitOfWork;
            _bldItEnvVariablesSettings = bldItSettingsMonitor.CurrentValue;
            _logger = logger;
        }

        [HttpGet(Routes.Jobs.GetName)]
        public async Task<IActionResult> GetByName(
            [FromRoute] Guid projectId, 
            [FromRoute] string jobName)
        {
            var projectExists = await _unitOfWork.ProjectRepo.ExistsAsync(projectId);
            if (!projectExists)
                throw new DomainNotFoundException($"Project with id '{projectId}' was not found");
            
            var job = await _unitOfWork.JobRepo.GetByNameAsync(projectId, jobName);
            if (job == null) 
                throw new DomainNotFoundException(
                    $"Job with name '{jobName}' was not found within project id: '{projectId}'");

            return Ok(job);
        }

        [HttpPost(Routes.Jobs.Post)]
        public async Task<IActionResult> CreateJob(
            [FromBody] JobCreationForm jobToCreate,
            [FromRoute] Guid projectId)
        {
            var project = await _unitOfWork.ProjectRepo.GetByIdAsync(projectId);
            if (project == null)
                throw new DomainNotFoundException($"Project with id '{projectId}' was not found");
            
            var existingJob = await _unitOfWork.JobRepo.GetByNameAsync(projectId, jobToCreate.JobName);
            if (existingJob != null)
            {
                throw new DomainValidationException(
                    $"Job with name {jobToCreate.JobName} " +
                    $"in project with id '{projectId}' already exists.", 
                    "Job names must be unique within each project");
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

            await _unitOfWork.JobRepo.AddAsync(job);
            await _unitOfWork.CompleteAsync();

            var locationUri = _uriService.GetJobByNameUri(projectId, job.JobName);
            return Created(locationUri, job);
        }

        private static void EnsureJobWorkspaceExists(string jobWorkspacePath)
        {
            if (!Directory.Exists(jobWorkspacePath))
                Directory.CreateDirectory(jobWorkspacePath);
        }
    }
}