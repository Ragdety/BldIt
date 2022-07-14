using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItExpressions.ExpressionTypes;
using BldIt.Lang.ValueObjects.BldItStatements;
using BldIt.Lang.ValueObjects.BldItStatements.Compound;
using BldIt.Lang.Visitors.ExpressionVisitors;

namespace BldIt.Lang.Visitors.StatementVisitors.Compound;

public class CompoundStatementVisitor : StatementVisitor
{
    public CompoundStatementVisitor(
        List<string> semanticErrors,
        Dictionary<string, Expression> globalVariables) 
        : base(semanticErrors, globalVariables) { }
    
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

        var expressionVisitor = new ExpressionVisitor(SemanticErrors, GlobalVariables);
        var expressionResult = expressionVisitor.Visit(context.singleIfBlock().expression());
        
        if (expressionResult.ExpressionType != ExpressionType.Boolean)
            throw new InvalidDataTypeException("Condition must be a boolean");
        
        var boolValue = (BoolValue) expressionResult;
        return boolValue.Value ? VisitSingleIfBlock(context.singleIfBlock()) : VisitElseBlock(context.elseBlock());
    }

    public override Statement VisitSingleIfBlock(BldItParser.SingleIfBlockContext context)
    {
        return Visit(context.block());
    }

    public override Statement VisitElseBlock(BldItParser.ElseBlockContext context)
    {
        return Visit(context.block());
    }
    
    public override Statement VisitWhileStatement(BldItParser.WhileStatementContext context)
    {
        Func<object?, bool> condition = context.WHILE().GetText() == "while"
                ? IsTrue
                : IsFalse;

        var txt = context.GetText();
        
        var expressionVisitor = new ExpressionVisitor(SemanticErrors, GlobalVariables);
        var expressionResult = expressionVisitor.Visit(context.expression());
        
        if (expressionResult.ExpressionType != ExpressionType.Boolean)
            throw new InvalidDataTypeException("Condition must be a boolean");
        
        var boolValue = (BoolValue) expressionResult;

        while (condition(boolValue.Value))
        {
            //Visit Block
            Visit(context.block());
            
            //Then reevaluate the condition
            expressionResult = expressionVisitor.Visit(context.expression());
        
            if (expressionResult.ExpressionType != ExpressionType.Boolean)
                throw new InvalidDataTypeException("Condition must be a boolean");
        
            boolValue = (BoolValue) expressionResult;
        }
 
        //Always should end in false, otherwise infinite loop...
        //Undecidable Turing Machine...?
        return new WhileStatementResult(boolValue.Value);
    }
    
    private static bool IsTrue(object? value)
    {
        if(value is bool b)
            return b;
        
        throw new InvalidDataTypeException("Expected boolean type");
    }

    private static bool IsFalse(object? value) => !IsTrue(value);
}