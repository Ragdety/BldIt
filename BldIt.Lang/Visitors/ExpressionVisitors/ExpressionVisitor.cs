using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;

namespace BldIt.Lang.Visitors.ExpressionVisitors;

public class ExpressionVisitor : BldItParserBaseVisitor<Expression>
{
    protected List<string> SemanticErrors { get; }

    public ExpressionVisitor(List<string> semanticErrors)
    {
        SemanticErrors = semanticErrors;
    }
    
    public override Expression VisitExpression(BldItParser.ExpressionContext context)
    {
        return base.VisitExpression(context);
    }
}