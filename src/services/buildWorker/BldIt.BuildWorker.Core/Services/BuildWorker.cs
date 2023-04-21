using System.Collections.ObjectModel;
using System.Text;
using BldIt.Api.Shared;
using BldIt.Api.Shared.Config;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Services.Storage;
using BldIt.Builds.Contracts.Enums;
using BldIt.BuildScheduler.Contracts.Contracts;
using BldIt.BuildWorker.Contracts.Contracts;
using BldIt.BuildWorker.Core.Hubs;
using BldIt.BuildWorker.Core.Hubs.Clients;
using BldIt.BuildWorker.Core.Interfaces;
using BldIt.BuildWorker.Core.Models;
using BldIt.BuildWorker.Core.ViewModels;
using BldIt.Shared.Git;
using BldIt.Shared.OSInformation;
using BldIt.Shared.Processes;
using CliWrap.EventStream;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace BldIt.BuildWorker.Core.Services;

public class BuildWorker : IBuildWorker
{
    private readonly ProcessService _processService;
    private readonly IRepository<WorkerBuildStep, Guid> _buildStepsRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<BuildWorker> _logger;
    private readonly IHubContext<BuildStreamHub> _buildHub;
    private readonly TemporaryFileStorage _temporaryFileStorage;
    private readonly BuildLogRegistry _buildLogRegistry;
    private readonly IGitManager _gitManager;
    private readonly IRepository<WorkerBuild, Guid> _buildRepository;
    private readonly IRepository<WorkerScmConfig, Guid> _scmConfigRepository;
    private readonly IRepository<WorkerGitHubCredential, Guid> _gitHubCredentialRepository;
    private readonly BldItWorkspaceConfig _bldItWorkspaceConfig;
    private readonly IRepository<WorkerJobConfig, Guid> _jobConfigRepository;
    private readonly IHubContext<BuildWorkersHub, IBuildWorkersClient> _buildWorkersHub;

    public BuildWorker(
        ProcessService processService, 
        IRepository<WorkerBuildStep, Guid> buildStepsRepository, 
        IPublishEndpoint publishEndpoint, 
        ILogger<BuildWorker> logger, 
        IHubContext<BuildStreamHub> buildHub, 
        TemporaryFileStorage temporaryFileStorage, 
        BuildLogRegistry buildLogRegistry, 
        IGitManager gitManager,
        IRepository<WorkerBuild, Guid> buildRepository, 
        IRepository<WorkerScmConfig, Guid> scmConfigRepository, 
        IRepository<WorkerGitHubCredential, Guid> gitHubCredentialRepository, 
        BldItWorkspaceConfig bldItWorkspaceConfig, 
        IRepository<WorkerJobConfig, Guid> jobConfigRepository, 
        IHubContext<BuildWorkersHub, IBuildWorkersClient> buildWorkersHub)
    {
        _processService = processService;
        _buildStepsRepository = buildStepsRepository;
        _publishEndpoint = publishEndpoint;
        _logger = logger;
        _buildHub = buildHub;
        _temporaryFileStorage = temporaryFileStorage;
        _buildLogRegistry = buildLogRegistry;
        _gitManager = gitManager;
        _buildRepository = buildRepository;
        _scmConfigRepository = scmConfigRepository;
        _gitHubCredentialRepository = gitHubCredentialRepository;
        _bldItWorkspaceConfig = bldItWorkspaceConfig;
        _jobConfigRepository = jobConfigRepository;
        _buildWorkersHub = buildWorkersHub;
    }

    private int CurrentProcessId { get; set; }
    public bool IsWorking { get; set; }
    public Guid WorkingBuildId { get; set; }
    public int WorkingBuildNumber { get; set; }
    public Guid WorkingJobId { get; set; }

    public async Task StartBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken)
    {
        IsWorking = true;
        WorkingBuildId = buildRequest.BuildId;
        WorkingBuildNumber = buildRequest.BuildNumber;
        WorkingJobId = buildRequest.JobId;
        
        //Invokes the client method
        await _buildWorkersHub.Clients.All.UpdateBuildWorkerAvailability(new BuildWorkerViewModel
        {
            IsWorking = IsWorking,
            BuildId = WorkingBuildId,
            BuildNumber = WorkingBuildNumber,
            JobId = WorkingJobId
        });
        
        _logger.LogInformation("Starting build request {BuildRequest}", buildRequest);
        
        await UpdateBuildStatusAsync(buildRequest, BuildStatus.Starting);

        // Fetch the build steps based on the buildConfig Id
        var buildSteps = await _buildStepsRepository
            .GetAllAsync(b => b.BuildConfigId == buildRequest.BuildConfigId);

        //Order them by number
        var orderedBuildSteps = buildSteps.OrderBy(k => k.BuildStepNumber);
        
        await UpdateBuildStatusAsync(buildRequest, BuildStatus.Running);
        
        //Create it outside the loop since we only want 1 log file per build
        var logFilePath = await _temporaryFileStorage.CreateTemporaryLogFileAsync(string.Empty);
        
        var scmConfig = await _scmConfigRepository.GetAsync(s => s.JobId == buildRequest.JobId);
        
        var repositoryPath = string.Empty;
        
        if (scmConfig is not null)
        {
            var jobConfig = await _jobConfigRepository.GetAsync(j => j.JobId == buildRequest.JobId);
            
            //This should eventually never happen, but just in case
            if (jobConfig is null)
            {
                _logger.LogError("Job config not found for job id {JobId}", buildRequest.JobId);
                _logger.LogWarning("Using temporary path for repository");
                // await SendBuildHubOutput("Job config not found for job id {JobId}", cancellationToken);
                // await CleanUpAsync(buildRequest, BuildResult.Failed, logFilePath, repositoryPath);
                // return;
                var reposPath = Path.Combine(_bldItWorkspaceConfig.TempPath(), "repos");
                repositoryPath = Path.Combine(reposPath, scmConfig.RepoName);
            }
            else
            {
                repositoryPath = Path.Combine(jobConfig.JobWorkspacePath, scmConfig.RepoName);
                _logger.LogInformation("Repository path: {RepositoryPath}", repositoryPath);
            }
            
            Directory.CreateDirectory(repositoryPath);
        }
        
        try
        {
            var exitCode = await RunLinuxProcess("apt-get update && apt-get install -y git", logFilePath, cancellationToken);
            
            if (exitCode != 0)
            {
                _logger.LogError("Error while updating apt-get");
                await SendBuildHubOutput("Error while updating apt-get", cancellationToken);
                await CleanUpAsync(buildRequest, BuildResult.Failed, logFilePath, repositoryPath);
                return;
            }
            
            //Perform git checkout if scm is available
            if (scmConfig is not null)
            {
                await PerformGitCheckoutAsync(scmConfig, repositoryPath, logFilePath, cancellationToken);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while performing git checkout");
            await SendBuildHubOutput("Error while performing git checkout:", cancellationToken);
            await SendBuildHubOutput(e.Message, cancellationToken);
            await CleanUpAsync(buildRequest, BuildResult.Failed, logFilePath, repositoryPath);
            
            //Don't proceed further if the git checkout failed. Clean up and return.
            return;
        }
        
        foreach (var buildStep in orderedBuildSteps)
        {
            _logger.LogInformation("Executing build step {BuildStep}", buildStep.Command);
            //Execute the command/script provided by the build step and check its exit code
            try
            {
                var exitCode = await RunBuildStepAsync(buildStep, logFilePath, repositoryPath, cancellationToken);
                if (exitCode == 0) continue;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error running build step command \'{BuildStepCommand}\'", buildStep.Command);
                await SendBuildHubOutput($"Error running build step command \'{buildStep.Command}\'", cancellationToken);
            }

            await CleanUpAsync(buildRequest, BuildResult.Failed, logFilePath, repositoryPath);
            
            //At this stage, the build worker is done doing its work.
            //We'll let the other services handle the build update by listening to the BuildResultUpdated event.
            return;
        }
        
        //If we reach this point, the build was successful.
        await CleanUpAsync(buildRequest, BuildResult.Success, logFilePath, repositoryPath);
    }

    public async Task CancelBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken)
    {
        //If it's done, just do nothing
        if (!IsWorking) return;
        
        _logger.LogInformation("Cancelling build request {BuildRequest}", buildRequest);
        await UpdateBuildStatusAsync(buildRequest, BuildStatus.Aborting);
        
        //TODO: Some Code to cancel the build
        
        await UpdateBuildResultAsync(buildRequest, BuildResult.Canceled);
        
        throw new NotImplementedException();
    }

    public async Task RestartBuildAsync(StartBuildRequest buildRequest, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Restarting build request {BuildRequest}", buildRequest);
        await CancelBuildAsync(buildRequest, cancellationToken);
        await StartBuildAsync(buildRequest, cancellationToken);
    }
    
    private async Task<int> RunBuildStepAsync(
        WorkerBuildStep buildStep, 
        string logFilePath,
        string repositoryPath,
        CancellationToken cancellationToken)
    {
        var extension = buildStep.Type switch 
        {
            BuildStepType.Batch => BldItApiConstants.Files.ScriptTypeExtensions.Batch,
            BuildStepType.Shell => BldItApiConstants.Files.ScriptTypeExtensions.Bash,
            BuildStepType.Python => BldItApiConstants.Files.ScriptTypeExtensions.Python,
            _ => throw new ArgumentOutOfRangeException(nameof(buildStep.Type))
        };

        var scriptContent = buildStep.Command;
        var scriptFilePath = await _temporaryFileStorage.CreateTemporaryScriptFileAsync(scriptContent, extension);

        if (buildStep.Type == BuildStepType.Python)
        {
            //Install python if needed
            await RunLinuxProcess("apt-get update && apt-get install -y python3 && apt-get install -y python3-pip", 
                logFilePath,
                cancellationToken);
            
            _processService.Program = "python3";
            _processService.Arguments = new[] {scriptFilePath};
        }
        else if (OsInfo.IsLinux())
        {
            _processService.Program = OsInfo.Paths.Linux.Shell;
            _processService.Arguments = new[] {scriptFilePath};
        }
        else
        {
            _processService.Program = scriptFilePath;
        }
        
        _processService.OutputLogPath = logFilePath;
        _processService.WorkingDirectory = repositoryPath;
        
        var environmentVariables = new Dictionary<string, string?>
        {
            {"WORKSPACE", repositoryPath},
            {"BUILD_NUMBER", WorkingBuildNumber.ToString()}
        };

        _processService.EnvironmentVariables = environmentVariables;

        _logger.LogInformation("Executing temporary script file \'{ScriptFilePath}\'", scriptFilePath);

        var exitCode = 0;
        var output = "";
        
        //Run the command and listen for events
        await foreach (var cmdEvent in _processService.ListenAsync(null, cancellationToken))
        {
            switch (cmdEvent)
            {
                case StartedCommandEvent started:
                    CurrentProcessId = started.ProcessId;
                    _logger.LogDebug("Step running with process id {ProcessId}", CurrentProcessId);
                    break;
                case StandardOutputCommandEvent stdOut:
                    output = stdOut.Text;
                    break;
                case StandardErrorCommandEvent stdErr:
                    output = stdErr.Text;
                    break;
                case ExitedCommandEvent exited:
                    exitCode = exited.ExitCode;
                    break;
            }

            //Append the log into log registry so new users who join the log room can see previous logs
            _buildLogRegistry.AppendBuildLog(WorkingBuildId, output);
            
            //Sends process output to groups listening (if any)
            await SendBuildHubOutput(output, cancellationToken);
        }

        _logger.LogInformation("Deleting temporary script file \'{ScriptFilePath}\'", scriptFilePath);
        var script = Path.GetFileName(scriptFilePath);
        _temporaryFileStorage.DeleteTemporaryFile(script);

        return exitCode;
    }
    
    private Func<string, Task> GetBuildHubOutputCallback(CancellationToken cancellationToken = default) => 
        async output => await SendBuildHubOutput(output, cancellationToken);

    private Task SendBuildHubOutput(string output, CancellationToken cancellationToken = default) => 
        _buildHub.Clients.Group(WorkingBuildId.ToString()).SendAsync("BuildOutputReceived", output, cancellationToken: cancellationToken);
    
    private async Task UpdateBuildStatusAsync(StartBuildRequest buildRequest, BuildStatus buildStatus)
    {
        await _publishEndpoint.Publish(new BuildStatusUpdated(
            buildRequest.BuildId,
            buildRequest.BuildConfigId, 
            buildRequest.BuildNumber, 
            buildStatus));
    }
    
    private async Task UpdateBuildResultAsync(StartBuildRequest buildRequest, BuildResult buildResult)
    {
        await _publishEndpoint.Publish(new BuildResultUpdated(
            buildRequest.BuildId,
            buildRequest.BuildConfigId, 
            buildRequest.BuildNumber, 
            buildResult));
    }

    private async Task UpdateBuildLogFile(StartBuildRequest buildRequest, string filePath)
    {
        _logger.LogInformation("Updating build log file for build {BuildId} to {FilePath}", buildRequest.BuildId, filePath);
        await _publishEndpoint.Publish(new BuildLogFileUpdate(buildRequest.BuildId, filePath));
    }
    
    private async Task CleanUpAsync(
        StartBuildRequest buildRequest, 
        BuildResult buildResult, 
        string logFilePath, 
        string repositoryPath)
    {
        //TODO: Maybe post build steps here?
        
        //TODO: Get rid of this crappy way of adding logs and FIX PROCESS SERVICE
        var buildLogs = _buildLogRegistry.GetBuildLogs(WorkingBuildId);
        
        var stringBuilder = new StringBuilder();
        foreach (var log in buildLogs)
        {
            stringBuilder.AppendLine(log);
        }
        
        //Write the logs to the log file
        await File.WriteAllTextAsync(logFilePath, stringBuilder.ToString());
        
        //TODO END 
        
        if (buildResult == BuildResult.Failed)
        {
            await UpdateBuildResultAsync(buildRequest, BuildResult.Failed);
            _logger.LogInformation("Build request {BuildRequest} has failed", buildRequest);
            await SendBuildHubOutput($"BUILD STATUS: {BuildResult.Failed.ToString()}");
        }
        else
        {
            await UpdateBuildResultAsync(buildRequest, BuildResult.Success);
            _logger.LogInformation("Build request {BuildRequest} has succeeded", buildRequest);
            await SendBuildHubOutput($"BUILD STATUS: {BuildResult.Success.ToString()}");
        }

        if (Directory.Exists(repositoryPath))
        {
            _logger.LogInformation("Deleting repo path: {repo}", repositoryPath);
            Directory.Delete(repositoryPath, true);
        }

        await UpdateBuildLogFile(buildRequest, logFilePath);
        IsWorking = false;
        
        //Stopped performing work, send update:
        await _buildWorkersHub.Clients.All.UpdateBuildWorkerAvailability(new BuildWorkerViewModel
        {
            IsWorking = IsWorking,
            BuildId = null,
            BuildNumber = -1,
            JobId = null,
        });
    }
    
    private async Task PerformGitCheckoutAsync(WorkerScmConfig scmConfig, string repositoryPath, string logFilePath, CancellationToken cancellationToken)
    {
        var cred = await _gitHubCredentialRepository.GetAsync(scmConfig.GitHubCredentialId);
        
        if (cred is null)
        {
            _logger.LogError("No GitHub credential found with id {GitHubCredentialId}", scmConfig.GitHubCredentialId);
            throw new Exception("No GitHub credential found");
        }
        
        _logger.LogInformation("Performing git commands with credential {GitHubCredentialId}", scmConfig.GitHubCredentialId);
        await SendBuildHubOutput("Performing git commands with credential: " + scmConfig.GitHubCredentialId, cancellationToken);

        //Initialize git manager
        await _gitManager.Initialize(repositoryPath);
        
        //git init
        //var errorlevel = await _gitManager.GitInit(cancellationToken, GetBuildHubOutputCallback(cancellationToken));
        var errorlevel = await RunLinuxProcess($"git init {repositoryPath}", logFilePath, cancellationToken, repositoryPath);
        
        if (errorlevel != 0)
        {
            _logger.LogError("Git init failed with errorlevel {ErrorLevel}", errorlevel);
            throw new Exception("git init failed with status code: " + errorlevel);
        }
        
        var remoteName = "origin";
        var branchName = scmConfig.Branch ?? "main";
        
        //TODO: Fix GitManager and add tests to it like ProcessService
        var url = $"https://{cred.GitHubUserName}:{cred.AccessToken}@github.com/{cred.GitHubUserName}/{scmConfig.RepoName}";
        
        //TODO: Mask the access token, for now not adding outputCallback
        //TODO: or add a placeholder and replace in disk 
        //Sending log instead
        //errorlevel = await _gitManager.GitRemoteAddWithAuth(remoteName, cred.GitHubUserName, scmConfig.RepoName, cred.AccessToken, cancellationToken);
        
        errorlevel = await RunLinuxProcess($"git remote add {remoteName} {url}", logFilePath, cancellationToken, repositoryPath);
        
        if (errorlevel != 0)
        {
            _logger.LogError("Git remote add failed with errorlevel {ErrorLevel}", errorlevel);
            throw new Exception("git remote add failed with status code: " + errorlevel);
        }
        
        //git fetch
        //errorlevel = await _gitManager.GitFetch(remoteName, branchName, cancellationToken, GetBuildHubOutputCallback(cancellationToken));
        errorlevel = await RunLinuxProcess($"git fetch {remoteName} {branchName}", logFilePath, cancellationToken, repositoryPath);
        
        if (errorlevel != 0)
        {
            _logger.LogError("Git fetch failed with errorlevel {ErrorLevel}", errorlevel);
            throw new Exception("git fetch failed with status code: " + errorlevel);
        }
        
        //git checkout
        //errorlevel = await _gitManager.GitCheckout(branchName, cancellationToken, GetBuildHubOutputCallback(cancellationToken));
        errorlevel = await RunLinuxProcess($"git checkout {branchName}", logFilePath, cancellationToken, repositoryPath);
        
        if (errorlevel != 0)
        {
            _logger.LogError("Git checkout failed with errorlevel {ErrorLevel}", errorlevel);
            throw new Exception("git checkout failed with status code: " + errorlevel);
        }
        
        //await RunLinuxProcess("ls", cancellationToken, repositoryPath);
    }
    
    //TODO: Make this run in a separate service allowing Windows and Linux
    private async Task<int> RunLinuxProcess(string command, string logFilePath, CancellationToken cancellationToken, string? workingDirectory = null) 
    {
        //TODO: Move this into a separate service/step
        var scriptFilePath = await _temporaryFileStorage.CreateTemporaryScriptFileAsync(command, ".sh");
        
        _processService.Program = OsInfo.Paths.Linux.Shell;
        _processService.Arguments = new[] {scriptFilePath};
        _processService.OutputLogPath = logFilePath;
        
        if (workingDirectory is not null)
        {
            _processService.WorkingDirectory = workingDirectory;
        }
        
        _logger.LogInformation("Running command: {Command}", command);

        var output = "";
        var error = "";
        var exitCode = 0;
        
        await foreach (var cmdEvent in _processService.ListenAsync(null, cancellationToken))
        {
            switch (cmdEvent)
            {
                case StartedCommandEvent started:
                    CurrentProcessId = started.ProcessId;
                    _logger.LogDebug("Step running with process id {ProcessId}", CurrentProcessId);
                    break;
                case StandardOutputCommandEvent stdOut:
                    output = stdOut.Text;
                    break;
                case StandardErrorCommandEvent stdErr:
                    error = stdErr.Text;
                    break;
                case ExitedCommandEvent exited:
                    exitCode = exited.ExitCode;
                    break;
            }

            //Append the log into log registry so new users who join the log room can see previous logs
            _buildLogRegistry.AppendBuildLog(WorkingBuildId, output);
            
            //Sends process errors to groups listening (if any)
            await SendBuildHubOutput(error, cancellationToken);
            
            //Sends process output to groups listening (if any)
            await SendBuildHubOutput(output, cancellationToken);
        }
        
        var script = Path.GetFileName(scriptFilePath);
        _temporaryFileStorage.DeleteTemporaryFile(script);

        return exitCode;
    }
}