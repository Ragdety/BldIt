namespace BldIt.Lang.Listeners;

public class SyntaxError
{
    public SyntaxError(int line, int column, string offendingSymbol, string message, List<string>? ruleStack)
    {
        Line = line;
        Column = column;
        OffendingSymbol = offendingSymbol;
        Message = message;
        RuleStack = ruleStack;
    }

    public int Line { get; }
    public int Column { get; }
    public string OffendingSymbol { get; }
    public string Message { get; }
    public List<string>? RuleStack { get; }

    public override string ToString()
    {
        return $"Token \"{OffendingSymbol}\" at line {Line}:{Column + 1}: {Message}";
    }
}