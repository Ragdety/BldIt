using Antlr4.Runtime;
using BldIt.Lang.Grammar;
using BldIt.Lang.Visitors;

namespace BldIt.Lang.Parsing;

public class GrammarParser
{
    private readonly BldItVisitor _bldItVisitor = new();
    public object? Parse(string fileContents)
    {
        var inputStream = new AntlrInputStream(fileContents);
        var bldItLexer = new BldItLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(bldItLexer);
        var bldItParser = new BldItParser(commonTokenStream);
        var tree = bldItParser.program();
        var rules = tree.Accept(_bldItVisitor);
        
        return rules;
    }
}