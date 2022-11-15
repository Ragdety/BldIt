using BldIt.Api.Shared.Settings;
using Microsoft.Extensions.Options;

namespace BldIt.Api.Shared.Config;

public class BldItWorkspacePathConfig
{
    private const string ProjectsFolderName = "Projects";
    private const string JobsFolderName = "Jobs";
    private const string TempFolderName = "Temp";
    private const string ProjectNamePrefix = "{projectName}";

    public BldItWorkspacePathConfig()
    {
        var bldItHome = Environment.GetEnvironmentVariable(BldItApiConstants.BldItEnvironmentNames.BLDIT_HOME);
        BldItHome = bldItHome ?? throw new ArgumentNullException(nameof(bldItHome));
    }
    
    public BldItWorkspacePathConfig(IOptionsMonitor<BldItWorkspacePathSettings> options)
    {
        var settings = options.CurrentValue;
        BldItHome = settings.BldItHome;
    }

    public string BldItHome { get; }
    
    public string ProjectsPath => Path.Combine(BldItHome, ProjectsFolderName);
    
    public string JobsPath => Path.Combine(ProjectsPath, ProjectNamePrefix, JobsFolderName);
    
    public string JobsPathForProject(string projectName) => JobsPath.Replace(ProjectNamePrefix, projectName);
    
    public string TempPath => Path.Combine(BldItHome, TempFolderName);
}