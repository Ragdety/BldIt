using Antlr4.Runtime;

namespace BldIt.Lang.Listeners;

public class ErrorListener : BaseErrorListener
{
    public static bool HasErrors { get; private set; }
    public static List<SyntaxError> SyntaxErrors { get; } = new();

    public override void SyntaxError(
        IRecognizer recognizer, 
        IToken offendingSymbol, 
        int line, 
        int charPositionInLine, 
        string msg,
        RecognitionException e)
    {
        HasErrors = true;
        List<string> stack = ((Parser) recognizer).GetRuleInvocationStack().ToList();
        stack.Reverse();

        //Dirty solution for comments "//" Since it'll be replaced with "  " and this throws an error.
        //So, skipping the error with this for now.
        //TODO: Implement DefaultErrorStrategy for comments later
        if (offendingSymbol.Text == "  ")
        {
            HasErrors = false;
            return;
        }
        
        SyntaxErrors.Add(
            new SyntaxError(line, charPositionInLine + 1, offendingSymbol.Text, msg, stack));
        
        // _log.LogError("Syntax Error!");
        // _log.LogError($"Token \"{offendingSymbol.Text}\" at line {line}:{charPositionInLine + 1}: {msg}");
        // _log.LogDebug("Rule Stack: {Stack}", stack);
    }
}