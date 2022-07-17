using BldIt.Lang.ValueObjects.BldItExpressions;

namespace BldIt.Lang.ValueObjects.BldItStatements.Simple;

public class FunctionCallStatement : Statement
{
    public string Name { get; }
    public IEnumerable<Expression> Arguments { get; }
    public Expression? Result { get; }

    public FunctionCallStatement(
        string name, 
        IEnumerable<Expression> arguments, 
        Expression? result)
    {
        Name = name;
        Arguments = arguments;
        Result = result;
    }
}