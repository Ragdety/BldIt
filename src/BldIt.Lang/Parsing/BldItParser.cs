using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using BldIt.Lang.Grammar;
using BldIt.Lang.Listeners;
using BldIt.Lang.Visitors;

namespace BldIt.Lang.Parsing;

public class BldItParser
{
    public Grammar.BldItParser? Parser(string source)
    {
        Grammar.BldItParser? parser = null;
        try
        {
            var inputStream = new AntlrInputStream(source);
            var bldItLexer = new BldItLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(bldItLexer);
            parser = new Grammar.BldItParser(commonTokenStream);
            
            //parser.ErrorHandler = new BldItErrorStrategy();
            
            //Syntax Error handling
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ErrorListener());
            
            //Semantic Error handling
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ErrorListener());
        }
        catch(Exception e)
        {
            Console.Error.Write(e.StackTrace);
        }

        return parser;
    }

    public BldItVisitor BldItVisitor(string source)
    {
        var visitor = new BldItVisitor();
        visitor.Visit(Parser(source)?.bldItFile());
        return visitor;
    }
    
    public object? Parse(string source)
    {
        return BldItVisitor(source).Visit(Parser(source)?.bldItFile());
    }
}