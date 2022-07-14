using Antlr4.Runtime.Tree;
using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionHelpers;
using Expression = BldIt.Lang.ValueObjects.BldItExpressions.Expression;
using ExpressionType = BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes.ExpressionType;

namespace BldIt.Lang.Visitors.ExpressionVisitors;

public class ExpressionVisitor : BldItParserBaseVisitor<Expression>
{
    protected List<string> SemanticErrors { get; }
    Dictionary<string, Expression> GlobalVariables { get; }

    public ExpressionVisitor(
        List<string> semanticErrors,
        Dictionary<string, Expression> globalVariables)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
    }

    public override Expression VisitConstant(BldItParser.ConstantContext context)
    {
        if (context.INTEGER() is { } intValue)
            return new IntegerValue(int.Parse(intValue.GetText()));
        
        if (context.FLOAT() is { } floatValue)
            return new FloatValue(float.Parse(floatValue.GetText()));
        
        if (context.STRING() is { } stringValue)
            return new StringValue(stringValue.GetText()[1..^1]); //Skip 1st and last char
        
        if(context.BOOL() is { } boolValue)
            return new BoolValue(boolValue.GetText() == "true");

        if (context.NULL() is { })
            return new NullValue(null);

        throw new InvalidDataTypeException("Data type not supported");
    }
    
    public override Expression VisitIdentifierExpr(BldItParser.IdentifierExprContext context)
    {
        var varName = context.IDENTIFIER().GetText();

        if (!GlobalVariables.ContainsKey(varName))
            throw new UndefinedVariableException(nameof(varName));
        
        return new Identifier(varName, GlobalVariables[varName]);
    }

    public override Expression VisitFunctionCallExpr(BldItParser.FunctionCallExprContext context)
    {
        return base.VisitFunctionCallExpr(context);
    }

    public override Expression VisitParenthesizedExpr(BldItParser.ParenthesizedExprContext context)
    {
        return base.VisitParenthesizedExpr(context);
    }

    public override Expression VisitNotExpr(BldItParser.NotExprContext context)
    {
        return base.VisitNotExpr(context);
    }

    public override Expression VisitMultiplicativeExpr(BldItParser.MultiplicativeExprContext context)
    {
        var (leftExpr, rightExpr, op) = GetLeftRightOperatorValues(context);
        var (left, right) = GetConstantValueRecursively(leftExpr, rightExpr);
        
        return op switch
        {
            "*" => (Expression) BasicOperationsHelper.Multiply(left, right)!,
            "/" => (Expression) BasicOperationsHelper.Divide(left, right)!,
            "%" => (Expression) BasicOperationsHelper.Modulo(left, right)!,
            _ => throw new NotSupportedException("Operator not supported")
        };
    }
    
    public override Expression VisitAdditiveExpr(BldItParser.AdditiveExprContext context)
    {
        // var left = Visit(context.expression(0));
        // var right = Visit(context.expression(1));
        // var op = context.addOp().GetText();
        //
        var (leftExpr, rightExpr, op) = GetLeftRightOperatorValues(context);
        var (left, right) = GetConstantValueRecursively(leftExpr, rightExpr);

        var result = op switch
        {
            "+" => BasicOperationsHelper.Add(left, right),
            "-" => BasicOperationsHelper.Subtract(left, right),
            _ => throw new NotSupportedException("Operator not supported")
        };

        Expression resultExpression = result switch
        {
            int i => new IntegerValue(i),
            float f => new FloatValue(f),
            _ => throw new CompilingException("Incorrect result type")
        };

        return resultExpression;
    }
    
    public override Expression VisitComparisonExpr(BldItParser.ComparisonExprContext context)
    {
        var (leftExpr, rightExpr, op) = GetLeftRightOperatorValues(context);
        var (left, right) = GetConstantValueRecursively(leftExpr, rightExpr);

        return op switch
        {
            "==" => new BoolValue(ComparisonHelper.Equal(left, right)),
            "!=" => new BoolValue(ComparisonHelper.NotEqual(left, right)),
            "<" =>  new BoolValue(ComparisonHelper.LessThan(left, right)),
            ">" =>  new BoolValue(ComparisonHelper.GreaterThan(left, right)),
            "<=" => new BoolValue(ComparisonHelper.LessThanOrEqual(left, right)),
            ">=" => new BoolValue(ComparisonHelper.GreaterThanOrEqual(left, right)),
            
            //Add semantic (or syntax?) error here, throw exception for now...
            _ => throw new NotSupportedException("Operator not supported")
        };
    }

    private Tuple<Expression, Expression, string> GetLeftRightOperatorValues(IParseTree context)
    {
        //After visiting recursively the left and right expressions, they should end up being constants
        var child1 = context.GetChild(0);
        var child2 = context.GetChild(1);
        var child3 = context.GetChild(2);
        
        var leftExpr = Visit(child1);
        var rightExpr = Visit(child3);
        var op = child2.GetText();

        if (leftExpr != null && rightExpr != null) return Tuple.Create(leftExpr, rightExpr, op);
        
        var leftToken  = child1.GetText();
        var rightToken = child3.GetText();
        throw new CompilingException($"{leftToken} or {rightToken} expression is incorrect");

        //if (leftExpr.ExpressionType == ExpressionType.Constant && rightExpr.ExpressionType == ExpressionType.Constant) 

        // SemanticErrors.Add($"Comparison between {leftExpr.ExpressionType} and {rightExpr.ExpressionType} must " +
        //                    "be between two constants. ");
        // throw new CompilingException(SemanticErrors[^1]);
    }

    private static Tuple<object, object> GetConstantValueRecursively(Expression leftExpr, Expression rightExpr)
    {
        var left = leftExpr switch
        {
            //Base cases:
            IntegerValue expr => expr.Value,
            FloatValue expr => expr.Value,
            
            //Recursively evaluate the expression of the identifier, ideal...?
            Identifier expr => GetConstantValueRecursively(expr.Value, rightExpr).Item1,
            //TODO: Add the other Expression types with their values here later...
            _ => throw new InvalidDataTypeException("Comparison between " + leftExpr.Type + " and " + rightExpr.Type +
                                                " is not supported.")
        };
        
        var right = rightExpr switch
        {
            IntegerValue expr => expr.Value,
            FloatValue expr => expr.Value,
            Identifier expr => GetConstantValueRecursively(leftExpr, expr.Value).Item2,
            _ => throw new InvalidDataTypeException("Comparison between " + leftExpr.Type + " and " + rightExpr.Type +
                                                " is not supported.")
        };

        return Tuple.Create(left, right);
    }
}