﻿using System.Diagnostics;

namespace BldIt.Shared.Processes
{
    /// <summary>
    /// Encapsulates an executable program.
    /// This class makes it easy to run a console app and have that app's output appear
    /// in the parent console's window, and to redirect input and output from/to files.
    /// </summary>
    /// <remarks>
    /// To use this class:
    /// (1) Create an instance.
    /// (2) Set the ProgramFileName property if a filename wasn't specified in the constructor.
    /// (3) Set other properties if required.
    /// (4) Call Run().
    /// </remarks>

    [Obsolete("Use ProcessService instead")]
    public class LauncherService : IProcessService
    {
        #region Constructor

        /// <summary>Runs the specified program file name.</summary>
        /// <param name="program">Name of the program file to run.</param>
        public LauncherService(string program)
        {
            Program = program;
            EnvironmentVariables = new Dictionary<string, string?>();

            _processStartInfo.ErrorDialog            = false;
            _processStartInfo.CreateNoWindow         = false;
            _processStartInfo.UseShellExecute        = false;
            _processStartInfo.RedirectStandardOutput = true;
            _processStartInfo.RedirectStandardError  = true;
            _processStartInfo.RedirectStandardInput  = true;
            _processStartInfo.WindowStyle            = ProcessWindowStyle.Hidden;
            _processStartInfo.Arguments              = "";
        }

        /// <summary>Constructor.</summary>
        public LauncherService(): this(string.Empty)
        {
        }

        #endregion  // Constructor
        
        #region Private Fields

        private StreamReader? _standardError;
        private StreamReader? _standardOutput;
        private StreamWriter? _standardInput;

        private string _standardInputFileName;
        private string _standardOutputFileName;
        private string _standardErrorFileName;

        private readonly ProcessStartInfo _processStartInfo = new();

        #endregion  // Private Fields

        #region Public Properties

        /// <summary>The filename (full pathname) of the executable.</summary>
        public string Program
        {
            get => _processStartInfo.FileName;
            set => _processStartInfo.FileName = value;
        }

        /// <summary>The command-line arguments passed to the executable when run. </summary>
        public string[] Arguments
        {
            get => _processStartInfo.Arguments.Split(' ');
            set => _processStartInfo.Arguments = string.Join(" ", value);
        }

        /// <summary>The working directory set for the executable when run.</summary>
        public string WorkingDirectory
        {
            get => _processStartInfo.WorkingDirectory;
            set => _processStartInfo.WorkingDirectory = value;
        }

        public IReadOnlyDictionary<string, string?> EnvironmentVariables { get; set; }

        /// <summary>
        /// The file to be used if standard input is redirected,
        /// or null or string. Empty to not redirect standard input.
        /// </summary>
        public string StandardInputFileName
        {
            set
            {
                _standardInputFileName = value;
                _processStartInfo.RedirectStandardInput = !string.IsNullOrEmpty(value);
            }
            get => _standardInputFileName;
        }

        /// <summary>
        /// The file to be used if standard output is redirected,
        /// or null or string. Empty to not redirect standard output.
        /// </summary>
        public string StandardOutputFileName
        {
            set
            {
                _standardOutputFileName = value;
                _processStartInfo.RedirectStandardOutput = !string.IsNullOrEmpty(value);
            }
            get => _standardOutputFileName;
        }

        /// <summary>
        /// The file to be used if standard error is redirected,
        /// or null or string. Empty to not redirect standard error.
        /// </summary>
        public string StandardErrorFileName
        {
            set
            {
                _standardErrorFileName = value;
                _processStartInfo.RedirectStandardError = !string.IsNullOrEmpty(value);
            }
            get => _standardErrorFileName;
        }

        #endregion  // Public Properties

        #region Public Methods
        
        public async Task<int> RunAsync(CancellationToken cancellationToken) => await RunAsync(null, cancellationToken);
        public Task<int> RunAsync(Func<string, Task>? outputCallback, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Run the executable with
        /// output and error streams redirection parameters
        /// and wait until the it has terminated.
        /// </summary>
        /// <param name="outputHandler">Handle where the standard output and error are written to.
        /// </param>
        /// <returns>The exit code returned from the executable.</returns>
        public async Task<int> RunAsync(Action<string>? outputHandler, CancellationToken cancellationToken)
        {
            Thread? standardInputThread = null;
            Thread? standardOutputThread = null;
            Thread? standardErrorThread = null;

            _standardInput  = null;
            _standardError  = null;
            _standardOutput = null;

            int exitCode;

            try
            {
                using Process process = new();
                process.StartInfo = _processStartInfo;

                // if (process.StartInfo.RedirectStandardInput)
                // {
                //     _standardInput = process.StandardInput;
                //     standardInputThread = StartThread(SupplyStandardInput, "StandardInput");
                // }
                //
                // if (process.StartInfo.RedirectStandardError)
                // {
                //     _standardError = process.StandardError;
                //     standardErrorThread = StartThread(WriteStandardError, "StandardError");
                // }
                //
                // if (process.StartInfo.RedirectStandardOutput)
                // {
                //     _standardOutput = process.StandardOutput;
                //     standardOutputThread = StartThread(WriteStandardOutput, "StandardOutput");
                // }

                if (outputHandler is not null)
                {
                    // These events will trigger our custom outputHandler
                    process.OutputDataReceived += (sendingProcess, outLine) =>
                    {
                        if (outLine.Data is not null) outputHandler(outLine.Data);
                    };
                    process.ErrorDataReceived += (sendingProcess, outLine) =>
                    {
                        if (outLine.Data is not null) outputHandler(outLine.Data);
                    };
                }
                

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                await process.WaitForExitAsync(cancellationToken);
                
                exitCode = process.ExitCode;
            }

            finally  // Ensure that the threads do not persist beyond the process being run
            {
                standardInputThread?.Join();
                standardOutputThread?.Join();
                standardErrorThread?.Join();
            }

            return exitCode;
        }

        #endregion  // Public Methods

        #region Private Methods

        /// <summary>Start a thread.</summary>
        /// <param name="startInfo">start information for this thread</param>
        /// <param name="name">name of the thread</param>
        /// <returns>thread object</returns>
        private static Thread StartThread(ThreadStart startInfo, string name)
        {
            Thread t = new(startInfo)
            {
                IsBackground = true,
                Name = name
            };
            t.Start();
            return t;
        }

        /// <summary>Thread which supplies standard input from the appropriate file to the running executable.</summary>
        private void SupplyStandardInput()
        {
            // feed text from the file a line at a time into the standard input stream
            using var reader = File.OpenText(_standardInputFileName);
            using var writer = _standardInput;
            if (writer is null) throw new ArgumentNullException(nameof(writer));
            writer.AutoFlush = true;

            for (;;)
            {
                var textLine = reader.ReadLine();

                if (textLine == null)
                    break;

                writer.WriteLine(textLine);
            }
        }

        /// <summary>Thread which outputs standard output from the running executable to the appropriate file.</summary>
        private void WriteStandardOutput()
        {
            using (var writer = File.CreateText(_standardOutputFileName))
            using (var reader = _standardOutput)
            {
                writer.AutoFlush = true;

                for (;;)
                {
                    var textLine = reader?.ReadLine();

                    if (textLine == null)
                        break;

                    writer.WriteLine(textLine);
                }
            }

            if (!File.Exists(_standardOutputFileName)) return;
            FileInfo info = new(_standardOutputFileName);

            // if the error info is empty or just contains eof etc.
            if (info.Length < 4)
                info.Delete();
        }

        /// <summary>Thread which outputs standard error output from the running executable to the appropriate file.</summary>
        private void WriteStandardError()
        {
            using (var writer = File.CreateText(_standardErrorFileName))
            using (var reader = _standardError)
            {
                writer.AutoFlush = true;

                for (;;)
                {
                    var textLine = reader?.ReadLine();

                    if (textLine == null)
                        break;

                    writer.WriteLine(textLine);
                }
            }

            if (!File.Exists(_standardErrorFileName)) return;
            FileInfo info = new(_standardErrorFileName);

            // if the error info is empty or just contains eof etc.
            if (info.Length < 4)
                info.Delete();
        }

        #endregion  // Private Methods
    }
}