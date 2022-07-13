using Antlr4.Runtime;

namespace BldIt.Lang.Listeners;

public class ErrorListener : BaseErrorListener
{
    public static bool HasError { get; private set; }

    public override void SyntaxError(
        IRecognizer recognizer, 
        IToken offendingSymbol, 
        int line, 
        int charPositionInLine, 
        string msg,
        RecognitionException e)
    {
        HasError = true;
        List<string> stack = ((Parser) recognizer).GetRuleInvocationStack().ToList();
        stack.Reverse();
        
        Console.Error.WriteLine("Syntax Error!");
        Console.Error.WriteLine($"Token \"{offendingSymbol.Text}\" " +
                                $"at line {line}:{charPositionInLine + 1}: {msg}");
        Console.Error.WriteLine($"Rule Stack: {stack}");
    }
}