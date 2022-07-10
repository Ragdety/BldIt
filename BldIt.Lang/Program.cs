using BldIt.Lang.Visitors;

//This should be a command line arg to be used like so: "bldit.exe SampleScripts/Sample1.bldit"
const string fileName = "C:\\Users\\ragde\\OneDrive\\Desktop\\Programming\\BldIt\\BldIt.Lang\\SampleScripts\\Sample1.bldit"; //args[0];

var fileContents = File.ReadAllText(fileName);
var bldItParser = new BldIt.Lang.Parsing.BldItParser();

//Main starting point of our programming language.
var parser = bldItParser.Parser(fileContents);
var bldItContext = parser.bldItFile();
var visitor = new BldItVisitor();
var ast = visitor.Visit(bldItContext);