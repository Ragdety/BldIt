using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItStatements;

namespace BldIt.Lang.Visitors.StatementVisitors;

public class StatementVisitor : BldItParserBaseVisitor<Statement>
{
    protected List<string> SemanticErrors { get; }

    public StatementVisitor(List<string> semanticErrors)
    {
        SemanticErrors = semanticErrors;
    }
    
    // public override Statement VisitStatement(BldItParser.StatementContext context)
    // {
    //     //But we can't do this since Statement is abstract...
    //     if (context.simpleStatement() is { } simpleStatement)
    //         return new SimpleStatement(simpleStatement);
    //     else if (context.compoundStatement() is { } compoundStatement) 
    //         return new CompoundStatement(compoundStatement);
    //     else
    //     {
    //         SemanticErrors.Add($"Invalid statement: {context.GetText()}");
    //     }
    //
    //     return new Statement();
    // }
}