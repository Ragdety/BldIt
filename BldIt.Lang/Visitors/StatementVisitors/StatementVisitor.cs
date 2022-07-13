using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItStatements;
using BldIt.Lang.ValueObjects.BldItStatements.Compound;
using BldIt.Lang.Visitors.StatementVisitors.Compound;
using BldIt.Lang.Visitors.StatementVisitors.Simple;

namespace BldIt.Lang.Visitors.StatementVisitors;

public class StatementVisitor : BldItParserBaseVisitor<Statement>
{
    protected List<string> SemanticErrors { get; }

    public StatementVisitor(List<string> semanticErrors)
    {
        SemanticErrors = semanticErrors;
    }
    
    public override Statement VisitStatement(BldItParser.StatementContext context)
    {
        if (context.simpleStatement() is { })
            return new SimpleStatementVisitor(SemanticErrors).VisitSimpleStatement(context.simpleStatement());
        if (context.compoundStatement() is { }) 
            return new CompoundStatementVisitor(SemanticErrors).VisitCompoundStatement(context.compoundStatement());
        SemanticErrors.Add($"Invalid statement: {context.GetText()}");
        throw new CompilingException("Invalid Statement");
    }
}