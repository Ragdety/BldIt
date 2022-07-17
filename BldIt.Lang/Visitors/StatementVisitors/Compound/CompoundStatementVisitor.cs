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
        Dictionary<string, Expression> globalVariables,
        Dictionary<string, Func<Expression?[], Expression?>> functions
        ) 
        : base(semanticErrors, globalVariables, functions) { }
    
    public override Statement VisitCompoundStatement(BldItParser.CompoundStatementContext context)
    {
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
        BoolValue boolValue;

        switch (expressionResult.ExpressionType)
        {
            case ExpressionType.Boolean:
                boolValue = (BoolValue) expressionResult;
                break;
            case ExpressionType.Identifier:
            {
                var identifier = (Identifier) expressionResult;
                boolValue = (BoolValue) GlobalVariables[identifier.Id];
                break;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (boolValue.Value)
            return Visit(context.singleIfBlock().block());

        //After checking single if statement, if we have else blocks, we need to check them too
        if (context.elseIfBlock().Length != 0)
        {
            //Loop through each else if blocks
            foreach (var eib in context.elseIfBlock())
            {
                expressionResult = expressionVisitor.Visit(eib.expression());
                if (expressionResult.ExpressionType != ExpressionType.Boolean)
                    throw new InvalidDataTypeException("Condition must be a boolean");
                
                boolValue = (BoolValue) expressionResult;
                
                //If the condition is not true, skip to the next else if block (eib) - continue
                if (!boolValue.Value) continue;
                
                //If the condition is true, goto block and return (since we don't want to execute the else block)
                return Visit(eib.block());
            }
            
            //This point is reached if all else if blocks are false
            //Make sure to check the else block if no else if block was executed
            if (context.elseBlock() is { } elseBlock)
                return Visit(elseBlock.block());
        }
        else if (context.elseBlock() is {} elseBlock)
            return Visit(elseBlock.block());

        return new IfStatementResult(boolValue.Value);
    }

    public override Statement VisitWhileStatement(BldItParser.WhileStatementContext context)
    {
        Func<object?, bool> condition = context.WHILE().GetText() == "while"
                ? IsTrue
                : IsFalse;

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