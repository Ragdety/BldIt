using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions;

public class FunctionCallExpression : Expression
{
    public FunctionCallExpression(
        string functionName, 
        IEnumerable<Expression> arguments, 
        Expression result) 
        : base(ExpressionType.FunctionCall)
    {
        FunctionName = functionName;
        Arguments = arguments;
        Result = result;
    }
    
    public string FunctionName { get; }
    
    public IEnumerable<Expression> Arguments { get; }
    
    //Must return a value
    public Expression Result { get; set; }
}
