using BldIt.Shared.OSInformation;
using BldIt.Shared.Processes;
using CliWrap.EventStream;

namespace BldIt.Shared.Utils;

public static class WhichUtil
{
    /// <summary>
    /// Runs "which" command
    /// </summary>
    /// <param name="cmd">Command to which you want to find the full path</param>
    /// <param name="outputCallback">Output callback in case which stdout should be redirected</param>
    /// <returns>The path of the command in cmd or null if not found</returns>
    public static async Task<string?> WhichAsync(string cmd, Func<string,Task>? outputCallback = null)
    {
        var process = GetWhichProcessService();

        process.Arguments = new[] {cmd};
        //var exitCode = 0;
        string? output = null;

        await foreach (var cmdEvent in process.ListenAsync(outputCallback, CancellationToken.None))
        {
            switch (cmdEvent)
            {
                case StandardOutputCommandEvent stdOut:
                    if (!string.IsNullOrEmpty(stdOut.Text.Trim()))
                    {
                        output = stdOut.Text;
                    }
                    break;
                // case ExitedCommandEvent exited:
                //     exitCode = exited.ExitCode;
                //     break;
            }
        }

        // if (exitCode != 0)
        // {
        //     //TODO: Log here instead
        //     //output = $"Could not find command: {cmd}";
        // }

        return output;
    }

    public static string Which(string cmd)
    {
        //Sync version of WhichAsync, this one requires us to manually search in PATH variable
        //rather than using the default "which" command
        //TODO: implement this
        throw new NotImplementedException();
    }

    private static ProcessService GetWhichProcessService()
    {
        return OsInfo.IsWindows() ? new ProcessService("where") : new ProcessService("which");
    }
}