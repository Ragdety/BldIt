using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.Listeners;
using BldIt.Lang.Visitors;

//This should be a command line arg to be used like so: "bldit.exe SampleScripts/Sample1.bldit"
const string filePath = "C:\\Users\\ragde\\OneDrive\\Desktop\\Programming\\BldIt\\BldIt.Lang\\SampleScripts\\Sample1.bldit"; //args[0];
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

var visitor = new ProgramVisitor();

if (ast is null) throw new ArgumentNullException(nameof(ast));
var bldItFile = visitor.VisitBldItFile(ast);
