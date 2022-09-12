using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;
using BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections;

public class StagesStatementVisitor : BldItParserBaseVisitor<StagesStatement>
{
    protected List<string> SemanticErrors { get; }
    protected Dictionary<string, Expression> GlobalVariables { get; }
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }
    protected Dictionary<string, Expression> GlobalEnv { get; }
    protected HashSet<Parameter> Parameters { get; }
    protected HashSet<Stage> Stages { get; }
 

    public StagesStatementVisitor(
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
        Stages = new HashSet<Stage>();
        
        //Add 2 functions here (GetEnv() and GetParam()), these will be able to be used inside the "script" step
        Functions["GetEnv"] = GetEnv;
        //Functions["GetParam"] = GetParam;
    }

    
    public override StagesStatement VisitStagesStatement(BldItParser.StagesStatementContext context)
    {
        var stagesStatement = context.GetText();
        if (context.stagesBlock() is {} stagesBlock)
            return VisitStagesBlock(stagesBlock);
        throw new CompilingException($"Invalid stages statement: {stagesStatement}");
    }

    public override StagesStatement VisitStagesBlock(BldItParser.StagesBlockContext context)
    {
        var stagesStatement = new StagesStatement();
        var stageStatements = context.stageStatement();
        var stageStatementVisitor = new StageStatementVisitor(
            SemanticErrors, 
            GlobalVariables, 
            Functions, 
            GlobalEnv, 
            Parameters);
        
        if (stageStatements.Length < 1)
            throw new CompilingException("Stages block must contain at least one stage");

        foreach (var stageStatement in stageStatements)
        {
            var t = stageStatement.GetText();
            var stage = stageStatementVisitor.VisitStageBlock(stageStatement.stageBlock());
            stagesStatement.AddStage(stage);
        }

        return stagesStatement;
    }
    
    private Expression GetEnv(Expression?[] arguments)
    {
        //If it doesn't contain arguments or more than 1 argument, throw an exception
        if (arguments.Length is > 1 or < 1)
            throw new CompilingException("GetEnv() function must have 1 argument only (the environment variable name)");

        //Get the env variable from the one and only function argument
        var envVariable = arguments[0];
        
        //Check if it is a string
        if (envVariable?.Type != typeof(StringValue))
            throw new CompilingException("GetEnv() function expects a string as the parameter");
        
        //Cast it from Expression to StringValue to be able to use it down below 
        var envVariableString = (StringValue) envVariable;
        
        //Gets environment variable from the pipeline (or even system env for the current process)
        if (GlobalEnv.ContainsKey(envVariableString.Value))
            return new StringValue(GlobalEnv[envVariableString.Value].ToString() ?? throw new InvalidOperationException());
        if (Environment.GetEnvironmentVariable(envVariableString.Value) is {} envVariableValue)
            return new StringValue(envVariableValue);
        throw new KeyNotFoundException($"Environment variable {envVariableString.Value} does not exist");
    }
}