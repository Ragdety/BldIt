namespace BldIt.Lang.ValueObjects.BldItStatements.Compound;

public class IfStatementResult : CompoundStatement
{
    public bool IsTrue { get; }
    
    public IfStatementResult(bool isTrue)
    {
        IsTrue = isTrue;
    }
}