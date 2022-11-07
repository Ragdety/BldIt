using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;

namespace BldIt.Api.Services.Processes
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

    public class LauncherService
    {
        #region Constructor

        /// <summary>Runs the specified program file name.</summary>
        /// <param name="programFileName">Name of the program file to run.</param>
        public LauncherService(string programFileName)
        {
            ProgramFileName = programFileName;

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

        private StreamReader _standardError;
        private StreamReader _standardOutput;
        private StreamWriter _standardInput;

        private string _standardInputFileName;
        private string _standardOutputFileName;
        private string _standardErrorFileName;

        private readonly ProcessStartInfo _processStartInfo = new();

        #endregion  // Private Fields

        #region Public Properties

        /// <summary>The filename (full pathname) of the executable.</summary>
        public string ProgramFileName
        {
            get => _processStartInfo.FileName;
            set => _processStartInfo.FileName = value;
        }

        /// <summary>The command-line arguments passed to the executable when run. </summary>
        public string Arguments
        {
            get => _processStartInfo.Arguments;
            set => _processStartInfo.Arguments = value;
        }

        /// <summary>The working directory set for the executable when run.</summary>
        public string? WorkingDirectory
        {
            get => _processStartInfo.WorkingDirectory;
            set => _processStartInfo.WorkingDirectory = value;
        }

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

        /// <summary>Add a set of name-value pairs into the set of environment variables available to the executable.</summary>
        /// <param name="variables">The name-value pairs to add.</param>
        public void AddEnvironmentVariables(StringDictionary variables)
        {
            if (variables == null)
                throw new ArgumentNullException(nameof(variables));

            StringDictionary environmentVariables = _processStartInfo.EnvironmentVariables;

            foreach (DictionaryEntry e in variables)
                environmentVariables[(string)e.Key] = (string)e.Value!;
        }

        /// <summary>
        /// Run the executable with
        /// output and error streams redirection parameters
        /// and wait until the it has terminated.
        /// </summary>
        /// <returns>The exit code returned from the executable.</returns>
        public int Run(Action<string> outputHandler)
        {
            Thread standardInputThread = null;
            Thread standardOutputThread = null;
            Thread standardErrorThread = null;

            _standardInput  = null;
            _standardError  = null;
            _standardOutput = null;

            int exitCode;

            try
            {
                using Process process = new();
                process.StartInfo = _processStartInfo;

                //Will play with Threads later 
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
                
                // These events will trigger our custom outputHandler
                process.OutputDataReceived += (sendingProcess, outLine) =>
                {
                    if (outLine.Data != null) outputHandler(outLine.Data);
                };
                process.ErrorDataReceived += (sendingProcess, outLine) =>
                {
                    if (outLine.Data != null) outputHandler(outLine.Data);
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                
                process.WaitForExit();
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
            using StreamReader reader = File.OpenText(_standardInputFileName);
            using StreamWriter writer = _standardInput;
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
            using (StreamWriter writer = File.CreateText(_standardOutputFileName))
            using (StreamReader reader = _standardOutput)
            {
                writer.AutoFlush = true;

                for (;;)
                {
                    var textLine = reader.ReadLine();

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
            using (StreamWriter writer = File.CreateText(_standardErrorFileName))
            using (StreamReader reader = _standardError)
            {
                writer.AutoFlush = true;

                for (;;)
                {
                    var textLine = reader.ReadLine();

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