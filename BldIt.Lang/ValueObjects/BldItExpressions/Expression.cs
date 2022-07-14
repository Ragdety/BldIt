using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions;

public abstract class Expression
{
    public ExpressionType ExpressionType { get; }

    //Default implementation of Type
    public virtual Type Type => GetType();

    protected Expression(ExpressionType expressionType)
    {
        ExpressionType = expressionType;
    }
}