using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItStatements;
using BldIt.Lang.Visitors.StatementVisitors.Compound;
using BldIt.Lang.Visitors.StatementVisitors.Simple;

namespace BldIt.Lang.Visitors.StatementVisitors;

public class StatementVisitor : BldItParserBaseVisitor<Statement>
{
    protected List<string> SemanticErrors { get; }
    protected Dictionary<string, Expression> GlobalVariables { get; }

    public StatementVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
    }
    
    public override Statement VisitStatement(BldItParser.StatementContext context)
    {
        if (context.simpleStatement() is { })
            return new SimpleStatementVisitor(SemanticErrors, GlobalVariables).VisitSimpleStatement(context.simpleStatement());
        if (context.compoundStatement() is { }) 
            return new CompoundStatementVisitor(SemanticErrors, GlobalVariables).VisitCompoundStatement(context.compoundStatement());
        SemanticErrors.Add($"Invalid statement: {context.GetText()}");
        throw new CompilingException("Invalid Statement");
    }
}