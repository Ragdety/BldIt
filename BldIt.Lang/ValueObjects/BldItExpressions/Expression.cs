using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions;

public abstract class Expression
{
    public ExpressionType ExpressionType { get; }

    //Default implementation of Type
    public virtual Type Type
    {
        get
        {
            return ExpressionType switch
            {
                ExpressionType.Boolean => typeof(BoolValue),
                ExpressionType.Additive => typeof(Constant<>),
                ExpressionType.Constant => typeof(Constant<>),
                ExpressionType.Void => typeof(VoidValue),
                ExpressionType.Identifier => typeof(Identifier),
                _ => GetType()
            };
        }
    }

    protected Expression(ExpressionType expressionType)
    {
        ExpressionType = expressionType;
    }
}