using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;
using BldIt.Lang.ValueObjects.BldItStatements;
using BldIt.Lang.ValueObjects.BldItStatements.Compound;
using BldIt.Lang.Visitors.ExpressionVisitors;

namespace BldIt.Lang.Visitors.StatementVisitors.Compound;

public class CompoundStatementVisitor : StatementVisitor
{
    public CompoundStatementVisitor(List<string> semanticErrors) : base(semanticErrors) { }
    
    public override Statement VisitCompoundStatement(BldItParser.CompoundStatementContext context)
    {
        var txt = context.GetText();
        if(context.ifStatement() is {} ifStatement)
            return VisitIfStatement(ifStatement);
        if (context.whileStatement() is {} whileStatement)
            return VisitWhileStatement(whileStatement);
        SemanticErrors.Add($"Unknown compound statement type: {context.GetText()}");
        throw new CompilingException(SemanticErrors[^1]);
    }
    
    public override Statement VisitIfStatement(BldItParser.IfStatementContext context)
    {
        var txt = context.GetText();

        var expressionVisitor = new ExpressionVisitor(SemanticErrors);
        var expressionResult = expressionVisitor.Visit(context.singleIfBlock().expression());
        
        if (expressionResult.ExpressionType != ExpressionType.Boolean)
            throw new InvalidTypeException("Condition must be a boolean");
        
        var value = (BoolValue) expressionResult;
        return value.Value ? VisitSingleIfBlock(context.singleIfBlock()) : VisitElseBlock(context.elseBlock());
    }

    public override Statement VisitSingleIfBlock(BldItParser.SingleIfBlockContext context)
    {
        return VisitBlock(context.block());
    }

    public override Statement VisitElseBlock(BldItParser.ElseBlockContext context)
    {
        return VisitBlock(context.block());
    }
}