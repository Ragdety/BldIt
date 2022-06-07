using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BldIt.Api.Form;
using BldIt.Api.Options;
using BldIt.Api.Repositories;
using BldIt.Api.Services;
using BldIt.Models;
using BldIt.Models.DataModels;
using BldIt.Models.Enums;
using BldIt.Models.Interfaces;
using BldIt.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BldIt.Api.Controllers
{
    [ApiController]
    public class JobController : ApiController
    {
        private readonly UriService _uriService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJobRepo _jobRepo;
        private readonly ResponsesService _responsesService;
        private readonly BldItEnvVariablesSettings _bldItEnvVariablesSettings;
        private readonly ILogger<JobController> _logger;

        public JobController(
            UriService uriService, 
            IUnitOfWork unitOfWork, 
            ResponsesService responsesService,
            IOptionsMonitor<BldItEnvVariablesSettings> bldItSettingsMonitor,
            ILogger<JobController> logger)
        {
            _uriService = uriService;
            _unitOfWork = unitOfWork;
            _jobRepo = _unitOfWork.JobRepo;
            _responsesService = responsesService;
            _bldItEnvVariablesSettings = bldItSettingsMonitor.CurrentValue;
            _logger = logger;
        }
        
        public static readonly List<BuildStep> InMemBuildSteps = new()
        {
            new BuildStep
            {
                Command = "ping google.com \n exit 1",
                Type = BuildStepType.Batch
            }
        };

        public static readonly List<Job> InMemJobs = new()
        {
            new Job
            {
                Id = "TestJob",
                JobDescription = "In memory job",
                JobWorkspacePath = "C:\\Users\\ragde\\OneDrive\\Desktop\\Programming\\BldIt\\BldIt.Api",
                BuildSteps = InMemBuildSteps,
                JobBuilds = new List<Build>()
            }
        };

        [HttpGet(Routes.Jobs.Get)]
        public async Task<IActionResult> Get(string jobName)
        {
            var job = InMemJobs.Find(j => j.Id == jobName);
            return Ok(job);
        }

        [HttpPost(Routes.Jobs.Post)]
        public async Task<IActionResult> CreateJob([FromBody] JobCreationForm jobToCreate)
        {
            var jobExists = await _jobRepo.JobExists(jobToCreate.Id);
            if (jobExists)
                return BadRequest(_responsesService.GenerateFailResponse(
                    new[] {$"Job with id {jobToCreate.Id} already exists."}));

            //These checks should be added in validation later:
            if (string.IsNullOrEmpty(jobToCreate.JobWorkspacePath.Trim()))
                jobToCreate.JobWorkspacePath = Path.Combine(_bldItEnvVariablesSettings.BLDIT_HOME, jobToCreate.Id);
            else if (!Directory.Exists(jobToCreate.JobWorkspacePath))
                return BadRequest(_responsesService.GenerateFailResponse(
                    new []{ $"Path to workspace: {jobToCreate.JobWorkspacePath} does not exist." }));

            var job = new Job
            {
                Id = jobToCreate.Id,
                JobDescription = jobToCreate.JobDescription,
                JobType = jobToCreate.JobType,
                UpdatedAt = DateTime.Now,
                JobWorkspacePath = jobToCreate.JobWorkspacePath
               // BuildSteps = jobToCreate.BuildSteps
            };
            
            //Will add a service for this later:
            //And add better error handling later as well
            try
            {
                Directory.CreateDirectory(job.JobWorkspacePath);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            //await _jobRepo.AddAsync(job);
            //await _unitOfWork.CompleteAsync();
                
            var locationUri = _uriService.GetJobUri(job.Id);
            return Created(locationUri, job);
        }
    }
}