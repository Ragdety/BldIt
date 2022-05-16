using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BldIt.Models.Enums;

namespace BldIt.Api.Services.Storage
{
    public class TemporaryFileStorage
    {
        public TemporaryFileStorage()
        {
            
        }

        public string GetTemporaryBuildFilePath(string? location, BuildStepType buildStepType)
        {
            var fileName = string.Concat(
                BldItConstraints.Files.TempPrefix,
                DateTime.Now.Ticks,
                BldItConstraints.Files.GenerateBuildStepFileType(buildStepType)
            );

            return $"{location}\\{fileName}";
        }

        public async Task CreateTemporaryBuildFile(string savePath, string command)
        {
            await using (FileStream fs = File.Create(savePath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(command);
                fs.Write(info, 0, info.Length);
            }

            EnsureCreated(savePath);
        }
        
        private static void EnsureCreated(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();
        }
    }
}