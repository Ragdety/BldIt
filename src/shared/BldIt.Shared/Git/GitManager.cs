using BldIt.Shared.Processes;
using BldIt.Shared.Utils;

namespace BldIt.Shared.Git;

public class GitManager : IGitManager
{
    private readonly IProcessService _processService;
    private string? _repositoryPath;
    private string? _gitPath;

    /// <summary>
    /// Instantiates an instance of GitManager to execute git commands
    /// </summary>
    /// <param name="processService">The process service to use when running git commands</param>
    /// <param name="repositoryPath">The local path to the repository. If not set, call Initialize(repoPath) to initialize it</param>
    /// <param name="gitPath">Git path to use. If not set, call Initialize(repoPath) to find it in the system</param>
    public GitManager(
        IProcessService processService,
        string? repositoryPath = null,
        string? gitPath = null)
    {
        _processService = processService;
        
        if (repositoryPath is not null)
        {
            _repositoryPath = repositoryPath;
        }
        
        if (gitPath is not null)
        {
            _gitPath = gitPath;
        }
    }

    /// <summary>
    /// Initialize gitPath by finding it in the system and setting the repository path.
    /// Note: If these are already set in constructor, this method overwrites them
    /// </summary>
    /// <param name="repositoryPath">The local path to the repository.</param>
    public async Task Initialize(string repositoryPath)
    {
        _gitPath = await GitPath();
        _repositoryPath = repositoryPath;
    }

    public async Task<int> GitInit(Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("init", outputCallback: outputCallback);
    }

    public Task<int> GitClone(string remoteUrl, Func<string, Task>? outputCallback = null)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GitRemoteAdd(string remoteName, string remoteUrl, Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("remote", $"add {remoteName} {remoteUrl}", outputCallback: outputCallback);
    }

    public async Task<int> GitRemoteAddWithAuth(string remoteName, string username, string repoName, string accessToken,
        Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("remote", 
            $"add {remoteName} https://{username}:{accessToken}@github.com/{username}:{repoName}",
            outputCallback: outputCallback);
    }

    public async Task<int> GitRemoteRemove(string remoteName, Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("remote", $"remove {remoteName}", outputCallback: outputCallback);
    }

    public async Task<int> GitAdd(string filePath, Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("add", filePath, outputCallback: outputCallback);
    }

    public async Task<int> GitCommit(string message, Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("commit", $"-m \"{message}\"", outputCallback: outputCallback);
    }

    public async Task<int> GitPush(string remoteName, string branchName, Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("push", $"{remoteName} {branchName}", outputCallback: outputCallback);
    }

    public async Task<int> GitPull(string remoteName, string branchName, Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("pull", $"{remoteName} {branchName}", outputCallback: outputCallback);
    }

    public async Task<int> GitFetch(string remoteName, string branchName, Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("fetch", $"{remoteName} {branchName}", outputCallback: outputCallback);
    }

    public async Task<int> GitCheckout(string branchName, Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("checkout", branchName, outputCallback: outputCallback);
    }

    public Task<int> GitBranch(string branchName, Func<string, Task>? outputCallback = null)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GitStatus(Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("status", outputCallback: outputCallback);
    }

    public async Task<int> GitConfig(string key, string value, Func<string, Task>? outputCallback = null)
    {
        return await RunGitCommand("config", $"{key} {value}", outputCallback: outputCallback);
    }

    private async Task<int> RunGitCommand(
        string command, 
        string additionalCommandLine = "", 
        string options = "", 
        Func<string, Task>? outputCallback = null,
        CancellationToken cancellationToken = default)
    {
        if (_gitPath is null)
        {
            throw new InvalidOperationException("GitManager has not been initialized. Call Initialize() first.");
        }
        
        if (_repositoryPath is null)
        {
            throw new InvalidOperationException("GitManager has not been initialized. Call Initialize() first.");
        }

        var args = new[] {command, options, additionalCommandLine};

        _processService.Program = _gitPath;
        _processService.Arguments = args;
        _processService.WorkingDirectory = _repositoryPath;

        return await _processService.RunAsync(outputCallback, cancellationToken);
    }
    
    private static async Task<string> GitPath()
    {
        var gitPath = await WhichUtil.WhichAsync("git");

        if (gitPath is null)
        {
            throw new InvalidOperationException("Could not find Git installed on the system. " +
                                                "Please make sure GIT is installed and available in the PATH.");
        }

        return gitPath;
    }
}