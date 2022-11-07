using BldIt.Lang.ValueObjects.BldItExpressions;

namespace BldIt.Lang.ValueObjects.BldItStatements.Simple;

public class ReturnStatement : Statement
{
    public ReturnStatement(Expression expression)
    {
        Expression = expression;
    }
    public Expression Expression { get; }
}