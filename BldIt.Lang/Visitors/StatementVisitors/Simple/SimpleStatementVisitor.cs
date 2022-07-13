using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItStatements;
using BldIt.Lang.ValueObjects.BldItStatements.Simple;
using BldIt.Lang.Visitors.ExpressionVisitors;

namespace BldIt.Lang.Visitors.StatementVisitors.Simple;

public class SimpleStatementVisitor : StatementVisitor
{
    private Dictionary<string, Expression> GlobalVariables { get; } = new();
    
    public SimpleStatementVisitor(List<string> semanticErrors) : base(semanticErrors) { }

    public override Statement VisitSimpleStatement(BldItParser.SimpleStatementContext context)
    {
        var txt = context.GetText();
        if(context.assignment() is {} assignment)
            return VisitAssignment(assignment);
        if (context.functionCall() is {} functionCall)
            return VisitFunctionCall(functionCall);
        SemanticErrors.Add($"Unknown statement type: {context.GetText()}");
        throw new CompilingException(SemanticErrors[^1]);
    }

    public override Statement VisitAssignment(BldItParser.AssignmentContext context)
    {
        var token = context.IDENTIFIER().Symbol;
        var line = token.Line;
        var column = token.Column + 1;
        
        var expressionVisitor = new ExpressionVisitor(SemanticErrors);
        var varName = context.IDENTIFIER().GetText();
        var value = expressionVisitor.VisitExpression(context.expression());
        
        if(GlobalVariables.ContainsKey(varName))
        {
            SemanticErrors.Add($"Variable {varName} already defined on line {line} column {column}");
        }
        else
        {
            GlobalVariables.Add(varName, value);
        }

        GlobalVariables[varName] = value;
        
        return new Assignment(varName, value);
    }

    public override Statement VisitFunctionCall(BldItParser.FunctionCallContext context)
    {
        return new FunctionCall();
    }
}