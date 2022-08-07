using BldIt.Lang.Exceptions;
using BldIt.Lang.Visitors;

//This should be a command line arg to be used like so: "bldit.exe SampleScripts/Sample1.bldit"
const string filePath = "C:\\Users\\Ragdety\\Desktop\\Programming\\BldIt\\BldIt.Lang\\SampleScripts\\Sample1.bldit"; //args[0];
const string blditFileType = "bldit";

var fileName = Path.GetFileName(filePath);
var fileType = fileName.Split('.')[1];
if (fileType != blditFileType)
{
    throw new CompilingException("Invalid file type");
}

var fileContents = File.ReadAllText(filePath);
var bldItParser = new BldIt.Lang.Parsing.BldItParser();

//Main starting point of our programming language.
var parser = bldItParser.Parser(fileContents);
var ast = parser?.bldItFile();

// if(ErrorListener.HasError)
// {
//     //Report error
//     throw new CompilingException("Errors found in file");
// }

var visitor = new BldItFileVisitor();

if (ast is null) throw new ArgumentNullException(nameof(ast));

try
{
    var bldItFile = visitor.VisitBldItFile(ast);
}
catch (Exception e)
{
    // foreach (var error in visitor.SemanticErrors)
    // {
    //     Console.Error.WriteLine(error);
    // }
    Console.Error.WriteLine(e.StackTrace);
    Console.Error.WriteLine(e.Message);
    //throw;
}
