using BldIt.Api.Shared.Settings;
using Microsoft.Extensions.Options;

namespace BldIt.Api.Shared.Config;

public class BldItWorkspaceConfig
{
    private readonly FileSettings _settings;
    
    private const string ProjectsFolderName = "projects";
    private const string JobsFolderName = "jobs";
    private const string BuildsFolderName = "builds";
    private const string TempFolderName = "temp";
    private const string FilesFolderName = "files";

    public BldItWorkspaceConfig(IOptionsMonitor<FileSettings> optionsMonitor)
    {
        _settings = optionsMonitor.CurrentValue;
        BldItHome = _settings.BldItHome;
        EnsureLocalDirectoryIsCreated(BldItHome);
    }

    public string BldItHome { get; }
    
    public string ProjectsPath()
    {
        var projectsPath = Path.Combine(BldItHome, ProjectsFolderName);
        return GetWorkspacePath(projectsPath);
    }
    
    public string JobsPath(string projectName)
    {
        var jobsPath = Path.Combine(ProjectsPath(), projectName, JobsFolderName);
        return GetWorkspacePath(jobsPath);
    }
    
    public string BuildsPath(string projectName, string jobName)
    {
        var buildsPath = Path.Combine(JobsPath(projectName), jobName, BuildsFolderName);
        return GetWorkspacePath(buildsPath);
    }
    
    public string BuildPath(string projectName, string jobName, int buildNumber)
    {
        var buildPath = Path.Combine(BuildsPath(projectName, jobName), buildNumber.ToString());
        return GetWorkspacePath(buildPath);
    }

    public string TempPath()
    {
        var tempPath = Path.Combine(BldItHome, TempFolderName);
        return GetWorkspacePath(tempPath);
    }

    public string FilesPath()
    {
        var filesPath = Path.Combine(BldItHome, FilesFolderName);
        return GetWorkspacePath(filesPath);
    }
    
    private string GetWorkspacePath(string path)
    {
        if (IsLocalProvider)
        {
            EnsureLocalDirectoryIsCreated(path);
            return path;
        }

        if (IsS3Provider)
        {
            throw new NotImplementedException("S3 not implemented yet");
        }

        throw new ArgumentException($"Invalid file provider {_settings.Provider}");
    }

    private static void EnsureLocalDirectoryIsCreated(string dir)
    {
        if(!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
    }
    
    private static void EnsureS3DirectoryIsCreated(string dir)
    {
        throw new NotImplementedException("S3 not implemented yet");
    }
    
    public bool IsLocalProvider => _settings.Provider == BldItApiConstants.Files.Providers.Local;
    public bool IsS3Provider => _settings.Provider == BldItApiConstants.Files.Providers.S3;
}