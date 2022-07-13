using System.Linq.Expressions;
using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionHelpers;
using Expression = BldIt.Lang.ValueObjects.BldItExpressions.Expression;
using ExpressionType = BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes.ExpressionType;

namespace BldIt.Lang.Visitors.ExpressionVisitors;

public class ExpressionVisitor : BldItParserBaseVisitor<Expression>
{
    protected List<string> SemanticErrors { get; }

    public ExpressionVisitor(List<string> semanticErrors)
    {
        SemanticErrors = semanticErrors;
    }

    public override Expression VisitComparisonExpr(BldItParser.ComparisonExprContext context)
    {
        //After visiting recursively the left and right expressions, they should end up being constants
        var leftExpr = Visit(context.expression(0));
        var rightExpr = Visit(context.expression(1));
        var op = context.compareOp().GetText();
        
        if(leftExpr.ExpressionType != ExpressionType.Constant || rightExpr.ExpressionType != ExpressionType.Constant)
        {
            SemanticErrors.Add($"Comparison between {leftExpr.ExpressionType} and {rightExpr.ExpressionType} must " +
                               "be between two constants. ");
            throw new CompilingException(SemanticErrors[^1]);
        }

        var (left, right) = ValidateComparisonType(leftExpr, rightExpr);

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

        throw new InvalidTypeException("Data type not supported");
    }

    private static Tuple<object, object> ValidateComparisonType(Expression leftExpr, Expression rightExpr)
    {
        object left = leftExpr switch
        {
            IntegerValue expr => expr.Value,
            FloatValue expr => expr.Value,
            _ => throw new InvalidTypeException("Comparison between " + leftExpr.Type + " and " + rightExpr.Type +
                                                " is not supported.")
        };
        
        object right = rightExpr switch
        {
            IntegerValue expr => expr.Value,
            FloatValue expr => expr.Value,
            _ => throw new InvalidTypeException("Comparison between " + leftExpr.Type + " and " + rightExpr.Type +
                                                " is not supported.")
        };

        return Tuple.Create(left, right);
    }
}