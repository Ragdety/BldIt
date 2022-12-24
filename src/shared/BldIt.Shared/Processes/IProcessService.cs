namespace BldIt.Shared.Processes;

/// <summary>
/// Represents a Process Service.
/// Can be inherited to create custom Process Services
/// </summary>
public interface IProcessService
{
    /// <summary>
    /// Represents the executable to run.
    /// This can be a path to a script, an executable, or an environment variable
    /// </summary>
    string Program { get; set; }

    /// <summary>
    /// Arguments for the specified program.
    /// </summary>
    string[] Arguments { get; set; }

    /// <summary>
    /// The working directory where the program will be executed.
    /// </summary>
    string WorkingDirectory { get; set; }
    
    /// <summary>
    /// Environment variables for this process.
    /// </summary>
    IReadOnlyDictionary<string, string?> EnvironmentVariables { get; set; }

    /// <summary>
    /// Run the program with the specified properties
    /// </summary>
    /// <param name="cancellationToken">Token to cancel execution</param>
    /// <returns>The exit code returned from the process</returns>
    Task<int> RunAsync(CancellationToken cancellationToken);
}