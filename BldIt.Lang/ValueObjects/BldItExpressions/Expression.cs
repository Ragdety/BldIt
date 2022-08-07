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
            switch (ExpressionType)
            {
                case ExpressionType.Boolean:
                    return typeof(BoolValue);
                case ExpressionType.Additive:
                    return typeof(Constant<>);
                case ExpressionType.Constant:
                    return typeof(Constant<>);
                case ExpressionType.Void:
                    return typeof(VoidValue);
                case ExpressionType.Identifier:
                    return typeof(Identifier);
                case ExpressionType.FunctionCall:
                    break;
                case ExpressionType.Parenthesized:
                    break;
                case ExpressionType.Not:
                    break;
                case ExpressionType.Multiplicative:
                    break;
                case ExpressionType.Comparison:
                    break;
                default:
                    return GetType();
            }

            return GetType();
        }
    }

    protected Expression(ExpressionType expressionType)
    {
        ExpressionType = expressionType;
    }
}