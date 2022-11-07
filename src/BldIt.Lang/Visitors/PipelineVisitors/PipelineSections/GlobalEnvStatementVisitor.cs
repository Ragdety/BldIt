using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections;
using BldIt.Lang.Visitors.ExpressionVisitors;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections;

public class GlobalEnvStatementVisitor : BldItParserBaseVisitor<GlobalEnvStatement>
{
    protected List<string> SemanticErrors { get; }
    protected Dictionary<string, Expression> GlobalVariables { get; }
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }
    protected Dictionary<string, Expression> GlobalEnv { get; }

    public GlobalEnvStatementVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables,
        Dictionary<string, Func<Expression?[], Expression?>> functions,
        Dictionary<string, Expression> globalEnv)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
        Functions = functions;
        GlobalEnv = globalEnv;
    }
    
    public override GlobalEnvStatement VisitGlobalEnvStatement(BldItParser.GlobalEnvStatementContext context)
    {
        var globalEnvStatement = context.GetText();
        if (context.globalEnvBlock() is {} globalEnv)
            return VisitGlobalEnvBlock(globalEnv);
        throw new CompilingException($"Invalid global environment statement: {globalEnvStatement}");
    }

    public override GlobalEnvStatement VisitGlobalEnvBlock(BldItParser.GlobalEnvBlockContext context)
    {
        return VisitEnvAssignments(context.envAssignments());
    }

    public override GlobalEnvStatement VisitEnvAssignments(BldItParser.EnvAssignmentsContext context)
    {
        var envs = context.envAssignment();
        var globalEnv = new GlobalEnvStatement();
        
        foreach (var env in envs)
        {
            var envName = env.IDENTIFIER().GetText();
            var expressionVisitor = new ExpressionVisitor(SemanticErrors, GlobalVariables, Functions);
            var envValue = expressionVisitor.Visit(env);
            globalEnv.SetEnvironmentVariable(envName, envValue);
            
            var val = (StringValue) envValue;
            
            //Set value as actual system env variable during the scope of pipeline execution.
            Environment.SetEnvironmentVariable(envName, val.Value);
            
            GlobalEnv.Add(envName, envValue);
        }

        return globalEnv;
    }
}