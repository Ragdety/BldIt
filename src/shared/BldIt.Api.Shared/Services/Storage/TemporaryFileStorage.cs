using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace BldIt.Api.Shared.Services.Storage
{
    public class TemporaryFileStorage
    {
        private readonly FileSettings _settings;

        public TemporaryFileStorage(IOptionsMonitor<FileSettings> optionsMonitor)
        {
            _settings = optionsMonitor.CurrentValue;
        }
        
        /// <summary>
        /// Saves a temporary file in the working directory from FileSettings based on the FormFile
        /// </summary>
        /// <param name="file">The file coming from the form</param>
        /// <returns>The file name created inside </returns>
        public async Task<string> SaveTemporaryFormFile(IFormFile file)
        {
            var fileName = GetBldItTempFileName(file.FileName);
            var savePath = GetSavePath(fileName);

            await using var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write);
            await file.CopyToAsync(fileStream);

            EnsureCreated(fileName);
            
            return fileName;
        }

        /// <summary>
        /// Creates a temporary file in the working directory from FileSettings
        /// with the specified content
        /// </summary>
        /// <param name="content">Content that will be included in the file</param>
        /// <param name="fileName">Optional file name if don't want name with Guid</param>
        /// <returns>The file name of the created file</returns>
        public async Task<string> CreateTemporaryFile(string content, string? fileName = default)
        {
            var fName = fileName ?? GetBldItTempFileName(Guid.NewGuid().ToString());
            var savePath = GetSavePath(fName);
            
            await using (var fs = File.Create(savePath))
            {
                var info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }

            EnsureCreated(fName);

            return fName;
        }

        /// <summary>
        /// Checks if the temp file exists inside the working directory from FileSettings
        /// </summary>
        /// <param name="fileName">Name of the file inside the working directory</param>
        /// <returns>True if the file exists, otherwise false</returns>
        public bool TemporaryFileExists(string fileName)
        {
            var path = GetSavePath(fileName);
            return File.Exists(path);
        }

        /// <summary>
        /// Deletes the temporary file in the working directory from FileSettings
        /// </summary>
        /// <param name="fileName">File name to delete</param>
        public void DeleteTemporaryFile(string fileName)
        {
            var path = GetSavePath(fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Gets the full path of the file inside the working directory from FileSettings
        /// </summary>
        /// <param name="fileName">File name that needs the full path</param>
        /// <returns>Full path of the fileName</returns>
        public string GetSavePath(string fileName)
        {
            return Path.Combine(_settings.WorkingDirectory, fileName);
        }

        /// <summary>
        /// Gets the bldit temp file name format
        /// </summary>
        /// <param name="fileName">Original file name to be renamed into bldit temp file format</param>
        /// <returns>New name of file in bldit temp file format</returns>
        public string GetBldItTempFileName(string fileName)
        {
            return string.Concat(
                BldItApiConstraints.Files.BldItTempPrefix,
                DateTime.Now.Ticks,
                Path.GetExtension(fileName)
            );
        }

        /// <summary>
        /// Ensures provided file exists inside working dir from FileSettings
        /// </summary>
        /// <param name="fileName">File to check existence</param>
        /// <exception cref="FileNotFoundException">
        /// Thrown if file doesn't exist in the working dir of FileSettings
        /// </exception>
        private void EnsureCreated(string fileName)
        {
            var savePath = GetSavePath(fileName);
            if (!File.Exists(savePath))
                throw new FileNotFoundException();
        }
    }
}