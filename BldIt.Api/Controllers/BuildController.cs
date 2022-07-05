using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BldIt.Api.Hubs;
using BldIt.Api.Services.Processes;
using BldIt.Api.Services.Storage;
using BldIt.Models.Exceptions;
using BldIt.Models.Forms;
using BldIt.Models.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BldIt.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class BuildController : ApiController
    {
        private readonly TemporaryFileStorage _temporaryFileStorage;
        private readonly LauncherService _launcherService;
        private readonly IHubContext<BuildStreamHub> _hub;
        private readonly IUnitOfWork _unitOfWork;

        public BuildController(
            TemporaryFileStorage temporaryFileStorage,
            LauncherService launcherService,
            IHubContext<BuildStreamHub> hub,
            IUnitOfWork unitOfWork)
        {
            _temporaryFileStorage = temporaryFileStorage;
            _launcherService = launcherService;
            _hub = hub;
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost(Routes.Builds.Build)]
        public async Task<IActionResult> Build(
            [FromRoute] Guid projectId, 
            [FromRoute] string jobName, 
            [FromBody] JobConfigurationForm jobConfiguration, 
            CancellationToken cancellationToken)
        {
            /*
             * Steps:
             * 0. Create batch/shell script temp file from buildStep.Command text
             * 1. Execute Build Steps from Job (in queue/thread/process)
             * 2. Return result (pass/fail, abort for later)
             * 3. Save Build in database (with its result)
             * 4. Return appropriate Http Result
             */

            var job = await _unitOfWork.JobRepo.GetByNameAsync(projectId, jobName);
            if (job == null)
                throw new DomainNotFoundException($"Job with name '{jobName}' was not found");
            
            var savePath =
                _temporaryFileStorage.GetTemporaryBuildFilePath(
                    job.JobWorkspacePath, jobConfiguration.BuildStepType);

            await _temporaryFileStorage.CreateTemporaryBuildFile(
                savePath, job.BuildSteps.First().Command);

            _launcherService.ProgramFileName = savePath;
            _launcherService.WorkingDirectory = job.JobWorkspacePath;

            //Sends process output to frontend
            async void OutputHandler(string output)
            {
                await _hub.Clients.All.SendAsync("OutputReceived", output, cancellationToken);
            }

            //Run process created by build-step command giving it the output to send to frontend
            var exitCode = _launcherService.Run(OutputHandler);
            return Ok($"Exit Code: {exitCode}");
        }
    }
}