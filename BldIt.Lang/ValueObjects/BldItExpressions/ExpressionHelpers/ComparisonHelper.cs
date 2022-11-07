using BldIt.Lang.Exceptions;

namespace BldIt.Lang.ValueObjects.BldItExpressions.ExpressionHelpers;

public static class ComparisonHelper
{
    public static bool LessThan(object? left, object? right)
    {
        return left switch
        {
            int leftInt when right is int rightInt => leftInt < rightInt,
            float leftFloat when right is float rightFloat => leftFloat < rightFloat,
            int lI when right is float rF => lI < rF,
            float lF when right is int rI => lF < rI,
            _ => throw new InvalidDataTypeException("Cannot perform less than operation on given types")
        };
    }
    
    public static bool GreaterThan(object? left, object? right)
    {
        return left switch
        {
            int leftInt when right is int rightInt => leftInt > rightInt,
            float leftFloat when right is float rightFloat => leftFloat > rightFloat,
            int lI when right is float rF => lI > rF,
            float lF when right is int rI => lF > rI,
            _ => throw new InvalidDataTypeException("Cannot perform greater than operation on given types")
        };
    }
    
    public static bool LessThanOrEqual(object? left, object? right)
    {
        return left switch
        {
            int leftInt when right is int rightInt => leftInt <= rightInt,
            float leftFloat when right is float rightFloat => leftFloat <= rightFloat,
            int lI when right is float rF => lI <= rF,
            float lF when right is int rI => lF <= rI,
            _ => throw new InvalidDataTypeException("Cannot perform less than or equal operation on given types")
        };
    }
    
    public static bool GreaterThanOrEqual(object? left, object? right)
    {
        return left switch
        {
            int leftInt when right is int rightInt => leftInt >= rightInt,
            float leftFloat when right is float rightFloat => leftFloat >= rightFloat,
            int lI when right is float rF => lI >= rF,
            float lF when right is int rI => lF >= rI,
            _ => throw new InvalidDataTypeException("Cannot perform greater than or equal operation on given types")
        };
    }
    
    public static bool Equal(object? left, object? right)
    {
        return left switch
        {
            int leftInt when right is int rightInt => leftInt == rightInt,
            float leftFloat when right is float rightFloat => leftFloat == rightFloat,
            int lI when right is float rF => lI == rF,
            float lF when right is int rI => lF == rI,
            string lS when right is string rS => lS == rS,
            _ => throw new InvalidDataTypeException($"Cannot perform not equal operation on given types: " +
                                                    $"{left?.GetType().Name} and {right?.GetType().Name}")
        };
    }
    
    public static bool NotEqual(object? left, object? right)
    {
        return left switch
        {
            int leftInt when right is int rightInt => leftInt != rightInt,
            float leftFloat when right is float rightFloat => leftFloat != rightFloat,
            int lI when right is float rF => lI != rF,
            float lF when right is int rI => lF != rI,
            string lS when right is string rS => lS != rS,
            _ => throw new InvalidDataTypeException($"Cannot perform not equal operation on given types: " +
                                                    $"{left?.GetType().Name} and {right?.GetType().Name}")
        };
    }
}