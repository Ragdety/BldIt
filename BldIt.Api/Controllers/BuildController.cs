using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BldIt.Api.Form;
using BldIt.Api.Hubs;
using BldIt.Api.Services.Processes;
using BldIt.Api.Services.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BldIt.Api.Controllers
{
    [ApiController]
    public class BuildController : ApiController
    {
        private readonly TemporaryFileStorage _temporaryFileStorage;
        private readonly LauncherService _launcherService;
        private readonly IHubContext<BuildStreamHub> _hub;

        public BuildController(
            TemporaryFileStorage temporaryFileStorage,
            LauncherService launcherService,
            IHubContext<BuildStreamHub> hub)
        {
            _temporaryFileStorage = temporaryFileStorage;
            _launcherService = launcherService;
            _hub = hub;
        }
        
        [HttpPost(Routes.Builds.Build)]
        public async Task<IActionResult> Build(
            [FromRoute] string jobName, 
            [FromBody] JobConfigurationForm jobConfiguration, 
            CancellationToken cancellationToken)
        {
            //Steps:
            //0. Create batch/shell script temp file from buildStep.Command text
            //1. Execute Build Steps from Job (in queue/thread/process)
            //2. Return result (pass/fail, abort for later)
            //3. Save Build in database (with its result)
            //4. Return appropriate Http Result
            
            var job = JobController.InMemJobs.Find(j => j.Id == jobName);
            
            if (job == null)
            {
                return NotFound($"Job {jobName} not found");
            }
            
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

            // var startInfo = new ProcessStartInfo
            // {
            //     FileName = savePath,
            //     CreateNoWindow = true,
            //     UseShellExecute = false,
            //     RedirectStandardOutput = true
            // };
            //
            // var outputStream = new StreamWriter("C:\\Users\\ragde\\OneDrive\\Desktop\\Programming\\BldIt\\BldIt.Api\\output.txt");
            //
            // using (var process = new Process{StartInfo = startInfo}) {
            //     process.OutputDataReceived += (sender, e) =>
            //     {
            //         if (!string.IsNullOrEmpty(e.Data))
            //         {
            //             outputStream.WriteLine(e.Data);
            //         }
            //     };
            //     
            //     process.Start();
            //     process.BeginOutputReadLine();
            //     await process.WaitForExitAsync();
            //     process.Close();
            //     outputStream.Close();
            // }
            
            return Ok($"Exit Code: {exitCode}");
        }
    }
}