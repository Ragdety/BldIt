using Antlr4.Runtime;
using BldIt.Lang.Grammar;
using BldIt.Lang.Visitors;

namespace BldIt.Lang.Parsing;

public class BldItParser
{
    public Grammar.BldItParser Parser(string source)
    {
        var inputStream = new AntlrInputStream(source);
        var bldItLexer = new BldItLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(bldItLexer);
        return new Grammar.BldItParser(commonTokenStream);
    }

    public BldItVisitor BldItVisitor(string source)
    {
        var visitor = new BldItVisitor();
        visitor.Visit(Parser(source).bldItFile());
        return visitor;
    }
    
    public object? Parse(string source)
    {
        return BldItVisitor(source).Visit(Parser(source).bldItFile());
    }
}