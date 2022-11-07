using System.Globalization;
using BldIt.Lang.Exceptions;

namespace BldIt.Lang.ValueObjects.BldItExpressions.ExpressionHelpers;

public static class BasicOperationsHelper
{
    public static object? Add(object? left, object? right)
    {
        return left switch
        {
            int l when right is int r => l + r,
            float lF when right is float rF => lF + rF,
            
            int lInt when right is float rFloat => lInt + rFloat,
            float lFloat when right is int rInt => lFloat + rInt,
            
            string leftString when right is string rightString => $"{leftString}{rightString}",
            
            string lStr when right is int rInt => $"{lStr}{rInt.ToString()}",
            int lInt when right is string rStr => $"{lInt.ToString()}{rStr}",
            
            string lStr when right is float rFlo => $"{lStr}{rFlo.ToString(CultureInfo.InvariantCulture)}",
            float lFlo when right is string rStr => $"{lFlo.ToString(CultureInfo.InvariantCulture)}{rStr}",
            
            string lStr when right is bool rBool => $"{lStr}{rBool.ToString()}",
            bool lBool when right is string rStr => $"{lBool.ToString()}{rStr}",
            
            string lStr when right is null => $"{lStr}null",
            null when right is string rStr => $"null{rStr}",
            _ => throw new InvalidDataTypeException($"Cannot add values of types {left?.GetType()} and {right?.GetType()}")
        };
    }
    
    public static object? Subtract(object? left, object? right)
    {
        return left switch
        {
            int l when right is int r => l - r,
            float lF when right is float rF => lF - rF,
            int lInt when right is float rFloat => lInt - rFloat,
            float lFloat when right is int rInt => lFloat - rInt,
            _ => throw new InvalidDataTypeException($"Cannot subtract values of types {left?.GetType()} and {right?.GetType()}")
        };
    }
    
    public static object? Multiply(object? left, object? right)
    {
        return left switch
        {
            int l when right is int r => l * r,
            float lF when right is float rF => lF * rF,
            int lInt when right is float rFloat => lInt * rFloat,
            float lFloat when right is int rInt => lFloat * rInt,
            _ => throw new InvalidDataTypeException($"Cannot multiply values of types {left?.GetType()} and {right?.GetType()}")
        };
    }
    
    public static object? Divide(object? left, object? right)
    {
        return left switch
        {
            int l when right is int r => l / r,
            float lF when right is float rF => lF / rF,
            int lInt when right is float rFloat => lInt / rFloat,
            float lFloat when right is int rInt => lFloat / rInt,
            _ => throw new InvalidDataTypeException($"Cannot divide values of types {left?.GetType()} and {right?.GetType()}")
        };
    }
    
    public static object? Modulo(object? left, object? right)
    {
        return left switch
        {
            int l when right is int r => l % r,
            float lF when right is float rF => lF % rF,
            int lInt when right is float rFloat => lInt % rFloat,
            float lFloat when right is int rInt => lFloat % rInt,
            _ => throw new InvalidDataTypeException($"Cannot use modulus with types {left?.GetType()} and {right?.GetType()}")
        };
    }
}