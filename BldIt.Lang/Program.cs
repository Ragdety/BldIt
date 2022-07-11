using BldIt.Lang.Exceptions;
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
var bldItContext = parser.bldItFile();
var visitor = new ProgramVisitor();
var ast = visitor.VisitBldItFile(bldItContext);