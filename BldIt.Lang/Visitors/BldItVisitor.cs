using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;

namespace BldIt.Lang.Visitors;

public class BldItVisitor : BldItBaseVisitor<object?>
{
    private Dictionary<string, object?> Variables { get; } = new();

    public override object? VisitAssignment(BldItParser.AssignmentContext context)
    {
        var varName = context.IDENTIFIER().GetText();
        var value = Visit(context.expression());

        Variables[varName] = value;
        
        return null;
    }

    public override object? VisitIdentifierExpr(BldItParser.IdentifierExprContext context)
    {
        var varName = context.IDENTIFIER().GetText();

        if (!Variables.ContainsKey(varName))
            throw new MissingVariableException(varName);
        
        return Variables[varName];
    }

    public override object? VisitConstant(BldItParser.ConstantContext context)
    {
        if (context.INTEGER() is { } intValue)
            return int.Parse(intValue.GetText());
        
        if (context.FLOAT() is { } floatValue)
            return float.Parse(floatValue.GetText());
        
        if (context.STRING() is { } stringValue)
            return stringValue.GetText()[1..^1]; //Skip 1st and last char
        
        if(context.BOOL() is { } boolValue)
            return boolValue.GetText() == "true";

        if (context.NULL() is { })
            return null;

        throw new NotSupportedException("Data type not supported");
    }

    public override object? VisitAdditiveExpr(BldItParser.AdditiveExprContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var op = context.addOp().GetText();
        
        return op switch
        {
            "+" => Add(left, right),
            "-" => Subtract(left, right),
            _ => throw new NotSupportedException("Operator not supported")
        };
    }
    
    public override object? VisitMultiplicativeExpr(BldItParser.MultiplicativeExprContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var op = context.multOp().GetText();
        
        return op switch
        {
            "*" => Multiply(left, right),
            "/" => Divide(left, right),
            "%" => Modulo(left, right),
            _ => throw new NotSupportedException("Operator not supported")
        };
    }
    
    public override object? VisitWhileBlock(BldItParser.WhileBlockContext context)
    {
        Func<object?, bool> condition = context.WHILE().GetText() == "while"
            ? IsTrue
            : IsFalse;

        while (condition(Visit(context.expression())))
        {
            Visit(context.block());
        }

        return null;
    }

    public override object? VisitComparisonExpr(BldItParser.ComparisonExprContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var op = context.compareOp().GetText();
        
        return op switch
        {
            //"==" => IsEquals(left, right),
            //"!=" => NotEquals(left, right),
            "<" => LessThan(left, right),
            //">" => GreaterThan(left, right),
            //"<=" => LessThanOrEqual(left, right),
            //">=" => GreaterThanOrEqual(left, right),
            _ => throw new NotSupportedException("Operator not supported")
        };
    }
    
    private static bool LessThan(object? left, object? right)
    {
        return left switch
        {
            int leftInt when right is int rightInt => leftInt < rightInt,
            float leftFloat when right is float rightFloat => leftFloat < rightFloat,
            int lI when right is float rF => lI < rF,
            float lF when right is int rI => lF < rI,
            _ => throw new InvalidTypeException("Cannot perform less than operation on given types")
        };
    }

    private static bool IsTrue(object? value)
    {
        if(value is bool b)
            return b;
        
        throw new InvalidTypeException("Expected boolean type");
    }

    private static bool IsFalse(object? value) => !IsTrue(value);

    private static object? Add(object? left, object? right)
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
            _ => throw new InvalidTypeException($"Cannot add values of types {left?.GetType()} and {right?.GetType()}")
        };
    }
    
    private static object? Subtract(object? left, object? right)
    {
        return left switch
        {
            int l when right is int r => l - r,
            float lF when right is float rF => lF - rF,
            int lInt when right is float rFloat => lInt - rFloat,
            float lFloat when right is int rInt => lFloat - rInt,
            _ => throw new InvalidTypeException($"Cannot subtract values of types {left?.GetType()} and {right?.GetType()}")
        };
    }
    
    private static object? Multiply(object? left, object? right)
    {
        return left switch
        {
            int l when right is int r => l * r,
            float lF when right is float rF => lF * rF,
            int lInt when right is float rFloat => lInt * rFloat,
            float lFloat when right is int rInt => lFloat * rInt,
            _ => throw new InvalidTypeException($"Cannot multiply values of types {left?.GetType()} and {right?.GetType()}")
        };
    }
    
    private static object? Divide(object? left, object? right)
    {
        return left switch
        {
            int l when right is int r => l / r,
            float lF when right is float rF => lF / rF,
            int lInt when right is float rFloat => lInt / rFloat,
            float lFloat when right is int rInt => lFloat / rInt,
            _ => throw new InvalidTypeException($"Cannot divide values of types {left?.GetType()} and {right?.GetType()}")
        };
    }
    
    private static object? Modulo(object? left, object? right)
    {
        return left switch
        {
            int l when right is int r => l % r,
            float lF when right is float rF => lF % rF,
            int lInt when right is float rFloat => lInt % rFloat,
            float lFloat when right is int rInt => lFloat % rInt,
            _ => throw new InvalidTypeException($"Cannot use modulus with types {left?.GetType()} and {right?.GetType()}")
        };
    }
}