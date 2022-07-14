using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;

namespace BldIt.Lang.Visitors;

public class BldItVisitor : BldItParserBaseVisitor<object?>
{
    private Dictionary<string, object?> Variables { get; } = new();

    public override object? VisitAssignment(BldItParser.AssignmentContext context)
    {
        var varName = context.IDENTIFIER().GetText();
        var value = Visit(context.expression());

        Variables[varName] = value;
        
        return null;
    }
    
    public override object? VisitBldItFile(BldItParser.BldItFileContext context)
    {
        //First visit the statements defined before pipeline.
        //(These can be some setup functions to use inside a pipeline 'script' block)
        foreach (var statement in context.statement())
        {
            Visit(statement);
        }
        var txt = context.pipeline().PIPELINE();
        if(context.pipeline().PIPELINE() != null)
        {
            var t = context.pipeline().GetText();
            Visit(context.pipeline());
        }
        else
            throw new CompilingException("No pipeline found. Pipeline must be defined.");

        return null;
    }


    public override object? VisitIdentifierExpr(BldItParser.IdentifierExprContext context)
    {
        var varName = context.IDENTIFIER().GetText();

        if (!Variables.ContainsKey(varName))
            throw new UndefinedVariableException(varName);
        
        return Variables[varName];
    }

    public override object? VisitIfStatement(BldItParser.IfStatementContext context)
    {
        var txt = context.GetText();
        if (Visit(context.singleIfBlock().expression()) is true)
        {
            Visit(context.singleIfBlock().block());
            //If first if returned true, skip everything else by returning null (exit this function)
            return null;
        }
        
        if (context.elseBlock() is {} elseBlock)
            VisitElseBlock(elseBlock);
        else
            throw new InvalidDataTypeException("Condition must be a boolean");
        
        //This is for else if blocks, will look into it later...
        //After checking single if statement, if we have else blocks, we need to check them too
        //Instead of VisitElseIfBlock, we're handling that code here (for now until I find a better solution)
        // if (context.elseIfBlock() is {} elseIfBlocks)
        // {
        //     var elseIfBlocksList = elseIfBlocks.Select(Visit).ToList();
        //     //Loop through each else if blocks
        //     foreach (var eib in elseIfBlocks)
        //     {
        //         //If the condition is not true, skip to the next else if block (eib) - continue
        //         if (Visit(eib.expression()) is not true) continue;
        //         
        //         //If the condition is true, goto block and return (since we don't want to execute the else block)
        //         Visit(eib.block());
        //         return null;
        //     }
        //     
        //     //This point is reached if all else if blocks are false
        //     //Make sure to check the else block if no else if block was executed
        //     if (context.elseBlock() is { } elseBlock)
        //         VisitElseBlock(elseBlock);
        // }
        // else if (context.elseBlock() is {} elseBlock)
        //     VisitElseBlock(elseBlock);
        // else
        //     throw new InvalidTypeException("Condition must be a boolean");

        return null;
    }

    public override object? VisitSingleIfBlock(BldItParser.SingleIfBlockContext context)
    {
        Visit(context.block());
        return null;
    }

    public override object? VisitElseBlock(BldItParser.ElseBlockContext context)
    {
        Visit(context.block());
        return null;
    }

    public override object? VisitWhileStatement(BldItParser.WhileStatementContext context)
    {
        Func<object?, bool> condition = context.WHILE().GetText() == "while"
            ? IsTrue
            : IsFalse
            ;

        var txt = context.GetText();

        while (condition(Visit(context.expression())))
        {
            Visit(context.block());
        }

        return null;
    }

    public override object? VisitBlock(BldItParser.BlockContext context)
    {
        Visit(context.statements());
        return null;
    }

    public override object? VisitStatements(BldItParser.StatementsContext context)
    {
        var statements = context.statement();
        foreach (var statement in statements)
        {
            Visit(statement);
        }
        return null;
    }

    public override object? VisitStatement(BldItParser.StatementContext context)
    {
        if(context.simpleStatement() is { } simpleStatement)
            Visit(simpleStatement);
        else if (context.compoundStatement() is { } compoundStatement)
            Visit(compoundStatement);
        else
            throw new Exception("Incorrect statement");
        
        return null;
    }

    public override object? VisitSimpleStatement(BldItParser.SimpleStatementContext context)
    {
        if (context.assignment() is { } assignment)
            Visit(assignment);
        else if (context.functionCall() is { } functionCall)
            Visit(functionCall);
        else 
            throw new Exception("Incorrect simple statement");

        return null;
    }

    public override object? VisitCompoundStatement(BldItParser.CompoundStatementContext context)
    {
        if (context.ifStatement() is { } ifStatement)
            Visit(ifStatement);
        else if (context.whileStatement() is { } whileStatement)
            Visit(whileStatement);
        else
            throw new NotSupportedException("Compound statement not supported");
        
        return null;
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

        throw new InvalidDataTypeException("Data type not supported");
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
            ">" => GreaterThan(left, right),
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
            _ => throw new InvalidDataTypeException("Cannot perform less than operation on given types")
        };
    }
    
    private static bool GreaterThan(object? left, object? right)
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

    private static bool IsTrue(object? value)
    {
        if(value is bool b)
            return b;
        
        throw new InvalidDataTypeException("Expected boolean type");
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
            _ => throw new InvalidDataTypeException($"Cannot add values of types {left?.GetType()} and {right?.GetType()}")
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
            _ => throw new InvalidDataTypeException($"Cannot subtract values of types {left?.GetType()} and {right?.GetType()}")
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
            _ => throw new InvalidDataTypeException($"Cannot multiply values of types {left?.GetType()} and {right?.GetType()}")
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
            _ => throw new InvalidDataTypeException($"Cannot divide values of types {left?.GetType()} and {right?.GetType()}")
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
            _ => throw new InvalidDataTypeException($"Cannot use modulus with types {left?.GetType()} and {right?.GetType()}")
        };
    }
}