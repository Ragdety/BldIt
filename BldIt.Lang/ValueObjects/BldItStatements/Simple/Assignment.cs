using BldIt.Lang.ValueObjects.BldItExpressions;

namespace BldIt.Lang.ValueObjects.BldItStatements.Simple;

public class Assignment : SimpleStatement
{
    public string Identifier { get; }
    public Expression Expression { get; } 
    
    public Assignment(string identifier, Expression expression)
    {
        Identifier = identifier;
        Expression = expression;
    }
}