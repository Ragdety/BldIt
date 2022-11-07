using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;
using BldIt.Lang.ValueObjects.BldItPipeline;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;
using BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages;
using Serilog;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections;

public class StagesStatementVisitor : BldItParserBaseVisitor<StagesStatement>
{
    protected List<string> SemanticErrors { get; }
    protected Dictionary<string, Expression> GlobalVariables { get; }
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }
    protected Dictionary<string, Expression> GlobalEnv { get; private set; }
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
        
        //Add 2 functions here (GetEnv() and GetParam()), these will be able to be used throughout the pipeline execution
        Functions["GetEnv"] = GetEnv;
        //Functions["GetParam"] = GetParam;
    }

    
    public override StagesStatement VisitStagesStatement(BldItParser.StagesStatementContext context)
    {
        //Set an environment variable for build result
        GlobalEnv["BUILD_RESULT"] = new StringValue("UNKNOWN");
        
        //Initialize these 2 functions to be used inside "stages" statement
        Functions["GetBuildResult"] = GetBuildResult;
        Functions["GetStageResult"] = GetStageResult;
        
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
            var stage = stageStatementVisitor.VisitStageBlock(stageStatement.stageBlock());
            stagesStatement.AddStage(stage);
            
            var buildResult = GlobalEnv["BUILD_RESULT"].ToString();
            
            //If the build is unknown, it means none of the steps failed, so we can set the build result to success
            if (buildResult == PipelineConstants.BuildConstants.BuildUnknownValue)
                GlobalEnv = BuildResultStatusHelper.SetBuildResult(GlobalEnv, PipelineConstants.BuildConstants.BuildSuccessValue);
        }

        return stagesStatement;
    }
    
    private Expression GetEnv(Expression?[] arguments)
    {
        //If it doesn't contain arguments or more than 1 argument, throw an exception
        if (arguments.Length is > 1 or < 1)
            throw new CompilingException("GetEnv(\"EnvName\") function must have 1 argument only (the environment variable name)");

        //Get the env variable from the one and only function argument
        var envVariable = arguments[0];
        
        //Check if it is a string
        if (envVariable?.Type != typeof(string))
            throw new CompilingException("GetEnv(\"EnvName\") function expects a string as the parameter");
        
        //Cast it from Expression to StringValue to be able to use it down below 
        var envVariableString = (StringValue) envVariable;
        
        //Gets environment variable from the pipeline (or even system env for the current process)
        if (GlobalEnv.ContainsKey(envVariableString.Value))
            return new StringValue(GlobalEnv[envVariableString.Value].ToString() ?? throw new InvalidOperationException());
        if (Environment.GetEnvironmentVariable(envVariableString.Value) is {} envVariableValue)
            return new StringValue(envVariableValue);
        throw new KeyNotFoundException($"Environment variable {envVariableString.Value} does not exist");
    }

    private Expression GetBuildResult(Expression?[] arguments)
    {
        if (arguments.Length > 1)
            throw new CompilingException("GetBuildResult() function must be invoked with 0 arguments");

        //Get the build result from the global environment
        var buildResult = GetEnv(new Expression?[] {new StringValue("BUILD_RESULT")});
        var buildResultString = (StringValue) buildResult;
        return buildResultString ?? throw new InvalidOperationException();
    }
    
    private Expression GetStageResult(Expression?[] arguments)
    {
        if (arguments.Length is > 1 or < 1)
            throw new CompilingException("GetStageResult(\"StageName\") function must have 1 argument only (the stage name)");

        //Get the stageName from the one and only function argument
        var stageName = arguments[0];
        
        //Check if it is a string
        if (stageName?.Type != typeof(string))
            throw new CompilingException("GetStageResult(\"StageName\") function expects a string as the parameter");
        
        //Cast it from Expression to StringValue to be able to use it down below 
        var stageNameString = (StringValue) stageName;
        
        if(Stages.Any(stage => stage.Name == stageNameString.Value))
            return new StringValue(Stages.First(stage => stage.Name == stageNameString.Value).State.ToString());
        throw new UndefinedStageException(stageNameString.Value);
    }
}