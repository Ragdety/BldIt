using BldIt.Lang.Exceptions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;

namespace BldIt.Lang.ValueObjects.BldItExpressions.ExpressionHelpers;

public static class ExpressionTypeHelper
{
    public static object GetExpressionValueFromExpression(Expression expression)
    {
        object exprValue = expression switch
        {
            IntegerValue expr => expr.Value,
            FloatValue expr => expr.Value,
            StringValue expr => expr.Value,
            BoolValue expr => expr.Value,
            _ => throw new InvalidDataTypeException($"Invalid data type {expression.ExpressionType}"),
        };
        
        return exprValue;
    }
    
    public static object GetValueFromType(Expression expression)
    {
        if (expression.Type == typeof(int))
        {
            var intValue = (IntegerValue)expression;
            return intValue;
        }
        if (expression.Type == typeof(float))
        {
            var floatValue = (FloatValue)expression;
            return floatValue;
        }
        if (expression.Type == typeof(string))
        {
            var stringValue = (StringValue)expression;
            return stringValue;
        }
        if (expression.Type == typeof(bool))
        {
            var boolValue = (BoolValue)expression;
            return boolValue;
        }
        throw new InvalidDataTypeException($"Invalid data type {expression.Type} for expression {expression.ToString()}");
    }
    
    private static Expression GetExpressionFromValue (object value)
    {
        return value switch
        {
            int expr => new IntegerValue(expr),
            float expr => new FloatValue(expr),
            string expr => new StringValue(expr),
            bool expr => new BoolValue(expr),
            _ => throw new InvalidDataTypeException($"Invalid data type {value.GetType()}"),
        };
    }
}