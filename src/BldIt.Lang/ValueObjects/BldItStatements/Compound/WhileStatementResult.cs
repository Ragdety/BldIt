namespace BldIt.Lang.ValueObjects.BldItStatements.Compound;

public class WhileStatementResult : Statement
{
    public bool Result { get; }

    public WhileStatementResult(bool result)
    {
        Result = result;
    }
}