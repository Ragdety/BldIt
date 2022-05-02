using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Api.Controllers
{
    [ApiController]
    public class BuildController : ApiController
    {
        [HttpPost(Routes.Builds.Build)]
        public async Task<IActionResult> Build([FromRoute] string jobName)
        {
            //Steps:
            //0. Create batch/shell script temp file from buildStep.Command text
            //1. Execute Build Steps from Job (in queue/thread/process)
            //2. Return result (pass/fail, abort for later)
            //3. Save Build in database (with its result)
            //4. Return appropriate Http Result
            
            var job = JobController.InMemJobs.Find(j => j.JobName == jobName);
            
            var fileName = string.Concat(
                BldItConstraints.Files.TempPrefix,
                DateTime.Now.Ticks,
                ".bat"
            );

            var savePath = $"C:\\Users\\ragde\\OneDrive\\Desktop\\Programming\\BldIt\\BldIt.Api\\{fileName}";

            await using (FileStream fs = System.IO.File.Create(savePath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(job.BuildSteps.First().Command);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            EnsureCreated(savePath);

            var startInfo = new ProcessStartInfo
            {
                FileName = savePath,
                CreateNoWindow = true,
                UseShellExecute = true
            };
            
            using (var process = new Process{StartInfo = startInfo}) {
                process.Start();
                await process.WaitForExitAsync();
            }
            
            return Ok();
        }

        private void EnsureCreated(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                throw new FileNotFoundException();
        }
    }
}