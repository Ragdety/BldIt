using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.Visitors.ExpressionVisitors;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineExpressions;

public class PipelineExpressionVisitor : BldItParserBaseVisitor<Expression>
{
    protected List<string> SemanticErrors { get; }
    protected Dictionary<string, Expression> GlobalVariables { get; }
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }
    protected Dictionary<string, Expression> GlobalEnv { get; }
    protected HashSet<Parameter> Parameters { get; }

    public PipelineExpressionVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables,
        Dictionary<string, Func<Expression?[], Expression?>> functions, 
        Dictionary<string, Expression> globalEnv, 
        HashSet<Parameter> parameters)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
        Functions = functions;
        GlobalEnv = globalEnv;
        Parameters = parameters;
    }

    public override Expression VisitPipelineExpression(BldItParser.PipelineExpressionContext context)
    {
        var pipelineExpressionText = context.GetText();
        if (context.expression() is not { } expression)
            throw new CompilingException($"Pipeline expression {pipelineExpressionText} is not valid");
        
        var expressionVisitor = new ExpressionVisitor(SemanticErrors, GlobalVariables, Functions);
        return expressionVisitor.Visit(expression);
    }
}