using Antlr4.Runtime;
using BldIt.Lang.Grammar;
using BldIt.Lang.Visitors;

//This should be a command line arg to be used like so: "bldit.exe SampleScripts/Sample1.bldit"
const string fileName = "C:\\Users\\ragde\\OneDrive\\Desktop\\Programming\\BldIt\\BldIt.Lang\\SampleScripts\\Sample1.bldit"; //args[0];

var fileContents = File.ReadAllText(fileName);

var inputStream = new AntlrInputStream(fileContents);
var bldItLexer = new BldItLexer(inputStream);
var commonTokenStream = new CommonTokenStream(bldItLexer);
var bldItParser = new BldItParser(commonTokenStream);

//Main starting point of our programming language.
var bldItContext = bldItParser.program();
// foreach (var tree in bldItContext.children)
// {
//     Console.WriteLine(tree.ToStringTree());
// }
var visitor = new BldItVisitor();     

var ast = visitor.Visit(bldItContext);