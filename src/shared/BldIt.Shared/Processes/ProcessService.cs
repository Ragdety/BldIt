using BldIt.Shared.OSInformation;
using CliWrap;

namespace BldIt.Shared.Processes;

/// <summary>
/// Service to execute a command line process
/// </summary>
/// <remarks>
/// To use this service:
/// (1) Create an instance (or inject it into your dependency injection container)
/// (2) Set the Program property if it wasn't specified in the constructor.
/// (3) Set other properties as needed.
/// (4) Call RunAsync().
/// 
/// Note: You can specify custom output and error streams in the RunAsync(outputCallback, errorCallback) method.
/// outputCallback and errorCallback are delegates that support custom or remote logging.
/// </remarks>
public class ProcessService : IProcessService
{
    /// <inheritdoc cref="IProcessService" />
    public string Program { get; set; }
    
    /// <inheritdoc cref="IProcessService" />
    public string[] Arguments { get; set; }
    
    /// <inheritdoc cref="IProcessService" />
    public string WorkingDirectory { get; set; }
    
    /// <inheritdoc cref="IProcessService" />
    public IReadOnlyDictionary<string, string?> EnvironmentVariables { get; set; }

    /// <summary>
    /// Log path where the output will be written to.
    /// </summary>
    public string OutputLogPath { get; set; }
    

    /// <summary>
    /// Creates a new instance with the specified program.
    /// </summary>
    /// <param name="program">
    /// Represents the executable to run.
    /// This can be a path to a script, an executable, or an environment variable.
    /// </param>
    public ProcessService(string program)
    {
        Program = program;
        Arguments = Array.Empty<string>();
        WorkingDirectory = Directory.GetCurrentDirectory();
        EnvironmentVariables = new Dictionary<string, string?>();
        OutputLogPath = string.Empty;
    }

    public ProcessService() : this(string.Empty) { }

    /// <inheritdoc cref="IProcessService" />
    public virtual async Task<int> RunAsync(CancellationToken cancellationToken) => await RunAsync(null, cancellationToken);

    /// <summary>
    /// Run the program with the specified properties and print output/error to screen.
    /// </summary>
    /// <param name="outputCallback">Callback to redirect the output asynchronously</param>
    /// <param name="cancellationToken">Token to cancel execution </param>
    /// <returns>The exit code returned from the process</returns>
    /// <remarks>
    /// If outputCallback is null,
    /// output will be printed to the parent process's standard output and error streams.
    /// Note: RunAsync() function without any parameters is a copy of this function with null callbacks.
    /// Therefore, calling RunAsync() is equivalent to calling RunAsync(null).
    /// </remarks>
    public virtual async Task<int> RunAsync(Func<string, Task>? outputCallback, CancellationToken cancellationToken)
    {
        var cmd = BuildCommonCommand();
        cmd = AddPipedCommand(cmd, outputCallback);
        var result = await cmd.ExecuteAsync(cancellationToken);
        return result.ExitCode;
    }

    /// <summary>
    /// Run the program with the specified properties and print output/error to screen.
    /// </summary>
    /// <param name="outputHandler">
    /// Handler to synchronously manage
    /// the output/error streams of the program run
    /// </param>
    /// <param name="cancellationToken">Token to cancel execution </param>
    /// <returns>The exit code returned from the process</returns>
    public virtual async Task<int> RunAsync(Action<string> outputHandler, CancellationToken cancellationToken)
    {
        var cmd = BuildCommonCommand();
        cmd = AddPipedCommand(cmd, outputHandler);
        var result = await cmd.ExecuteAsync(cancellationToken);
        return result.ExitCode;
    }
    
    

    private Command BuildCommonCommand()
    {
        if (string.IsNullOrEmpty(Program)) throw new ArgumentNullException(nameof(Program));

        var cmd = Cli.Wrap(Program)
            .WithWorkingDirectory(WorkingDirectory)
            .WithValidation(CommandResultValidation.None);

        if (OsInfo.IsLinux())
        {
            cmd = cmd.WithCredentials(c =>
            {
                c.SetUserName(OsUser.Linux.Root);
            });
        }

        if (Arguments.Any())
            cmd = cmd.WithArguments(Arguments);
        
        if(EnvironmentVariables.Any())
            cmd = cmd.WithEnvironmentVariables(EnvironmentVariables);

        return cmd;
    }

    private Command AddPipedCommand(Command cmd, Func<string, Task>? outputCallback)
    {
        //Pipe command into outputCallback
        if (outputCallback is not null)
            cmd |= outputCallback;
        //Pipe command into parent process
        else
            cmd |= (Console.OpenStandardOutput(), Console.OpenStandardError());
        
        if (!string.IsNullOrEmpty(OutputLogPath))
            cmd |= PipeTarget.ToFile(OutputLogPath);
        
        return cmd;
    }
    
    private Command AddPipedCommand(Command cmd, Action<string> outputHandler)
    {
        //Pipe command into outputHandler
        cmd |= outputHandler;
        
        if (!string.IsNullOrEmpty(OutputLogPath))
            cmd |= PipeTarget.ToFile(OutputLogPath);
        
        return cmd;
    }
}