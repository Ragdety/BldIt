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
    
    //Dict<identifier, function<arguments, result>>
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }

    public StatementVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables, 
        Dictionary<string, Func<Expression?[], Expression?>> functions)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
        Functions = functions;
    }
    
    public override Statement VisitStatement(BldItParser.StatementContext context)
    {
        if (context.simpleStatement() is { })
            return new SimpleStatementVisitor(SemanticErrors, GlobalVariables, Functions).VisitSimpleStatement(context.simpleStatement());
        if (context.compoundStatement() is { })
        {
            var compoundStatementVisitor = new CompoundStatementVisitor(SemanticErrors, GlobalVariables, Functions);
            return compoundStatementVisitor.VisitCompoundStatement(context.compoundStatement());
        }
            
        SemanticErrors.Add($"Invalid statement: {context.GetText()}");
        throw new CompilingException("Invalid Statement");
    }
}