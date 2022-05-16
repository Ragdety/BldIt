using System.Collections.Generic;
using System.Threading.Tasks;
using BldIt.Models;
using BldIt.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Api.Controllers
{
    [ApiController]
    public class JobController : ApiController
    {
        public JobController()
        {
            
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
                JobName = "TestJob",
                JobDescription = "In memory job",
                JobWorkspacePath = "C:\\Users\\ragde\\OneDrive\\Desktop\\Programming\\BldIt\\BldIt.Api",
                BuildSteps = InMemBuildSteps,
                JobBuilds = new List<Build>()
            }
        };

        [HttpGet(Routes.Jobs.Get)]
        public async Task<IActionResult> Get(string jobName)
        {
            var job = InMemJobs.Find(j => j.JobName == jobName);
            return Ok(job);
        }
    }
}