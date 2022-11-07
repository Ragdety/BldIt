using BldIt.Lang.Exceptions;
using BldIt.Lang.Listeners;
using BldIt.Lang.Visitors;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Console(
        outputTemplate: "[{Level} - Pipeline] {Message}{NewLine}{Exception}")
    .CreateLogger();

Log.Logger.Information("Starting Pipeline");

//C:\\Users\\ragde\\OneDrive\\Desktop\\Programming\\BldIt\\BldIt.Lang\\SampleScripts\\Sample1.bldit

//This should be a command line arg to be used like so: "bldit.exe SampleScripts/Sample1.bldit"
var filePath = args[0];
const string blditFileType = "bldit";

var fileName = Path.GetFileName(filePath);
var fileType = fileName.Split('.')[1];
if (fileType != blditFileType)
    throw new CompilingException("Invalid file type");

var fileContents = File.ReadAllText(filePath);
var bldItParser = new BldIt.Lang.Parsing.BldItParser();

//Main starting point of the DSL.
var parser = bldItParser.Parser(fileContents);
var ast = parser?.bldItFile();
if (ast is null) throw new ArgumentNullException(nameof(ast));

//Walker to keep track of rule stack inside BldItParserListener
//Singleton rule stack class
// var tnsWalker = new ParseTreeWalker();
// var tnsListener = new BldItParserListener(parser!);
// tnsWalker.Walk(tnsListener, ast);

if(ErrorListener.HasErrors)
{
    //Report error
    //throw new CompilingException("Errors found in file");
    Log.Logger.Error("Syntax errors found in file:");
    foreach (var syntaxError in ErrorListener.SyntaxErrors)
    {
        Log.Logger.Error(syntaxError.ToString());
        if(syntaxError.RuleStack is not null && syntaxError.RuleStack.Count > 0)
            Log.Logger.Debug("Rule Stack: {Stack}", syntaxError.RuleStack);
    }
}

var visitor = new BldItFileVisitor();

try
{
    var bldItFile = visitor.VisitBldItFile(ast);
}
catch (Exception e)
{
    Log.Logger.Error(e.StackTrace);
    Log.Logger.Error(e.Message);
    Log.Logger.Error("Finished with errors");
    Environment.ExitCode = 1;
}