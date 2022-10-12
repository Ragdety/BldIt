using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;
using BldIt.Lang.Visitors.PipelineVisitors.PipelineSections;
using Serilog;

namespace BldIt.Lang.Visitors.PipelineVisitors;

public class PipelineVisitor : BldItParserBaseVisitor<Pipeline>
{
    /// <summary>
    /// Represents semantic errors when parsing the file
    /// </summary>
    protected List<string> SemanticErrors { get; }
    
    /// <summary>
    /// Represents global variables defined before the pipeline.
    /// </summary>
    protected Dictionary<string, Expression> GlobalVariables { get; }
    
    /// <summary>
    /// Represents system environment variables during the lifetime of the pipeline execution.
    /// </summary>
    protected Dictionary<string, Expression> GlobalEnv { get; }
    
    /// <summary>
    /// Represents the set of parameters in the pipeline
    /// </summary>
    protected HashSet<Parameter> Parameters { get; }
    
    /// <summary>
    /// Represents functions of the bldit file context.
    /// </summary>
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }
    
    /// <summary>
    /// Represents the set of stages in the pipeline.
    /// No duplicate stage names are allowed.
    /// </summary>
    protected HashSet<Stage> Stages { get; private set; }

    public PipelineVisitor(
        List<string> semanticErrors, 
        Dictionary<string, Expression> globalVariables, 
        Dictionary<string, Func<Expression?[], Expression?>> functions)
    {
        SemanticErrors = semanticErrors;
        GlobalVariables = globalVariables;
        Functions = functions;
        Parameters = new HashSet<Parameter>();
        GlobalEnv = new Dictionary<string, Expression>();
        Stages = new HashSet<Stage>();
    }
    
    public override Pipeline VisitPipeline(BldItParser.PipelineContext context)
    {
        var pipeline = new Pipeline();
        
        /*
         * We will pass the semantic errors, global variables and functions to the visitor.
         * And after we visit it, it will contain the global environment variables in the GlobalEnv dictionary.
         */
        var globalEnvVisitor = new GlobalEnvStatementVisitor(
            SemanticErrors, 
            GlobalVariables,
            Functions,
            GlobalEnv);
        
        /*
         * We will pass the semantic errors, global variables and functions to the visitor.
         * And after we visit it, it will contain the parameters in the Parameters hashset.
         * ParameterStatementVisitor doesn't need to know about the global environment variables.
         */
        var parameterStatementVisitor = new ParameterStatementVisitor(
            SemanticErrors,
            GlobalVariables,
            Functions,
            Parameters);
        
        var stageStatementVisitor = new StagesStatementVisitor(
            SemanticErrors,
            GlobalVariables,
            Functions,
            GlobalEnv,
            Parameters);

        for (var i = 0; i < context.ChildCount; i++)
        {
            switch (i)
            {
                //GlobalEnvStatement is index 0
                case 0:
                    pipeline.SetGlobalEnv(globalEnvVisitor
                        .VisitGlobalEnvStatement(context.globalEnvStatement()));
                    break;
                //ParameterStatement is index 1
                case 1:
                    pipeline.SetParameterStatement(parameterStatementVisitor
                        .VisitParameterStatement(context.parameterStatement()));
                    break;
                //StagesStatement is index 2
                case 2:
                    pipeline.SetStageStatement(stageStatementVisitor
                        .VisitStagesStatement(context.stagesStatement()));

                    Stages = pipeline.StagesStatement.Stages;
                    var buildSuccess = BuildResultStatusHelper.IsBuildSuccess(GlobalEnv);
                    if (!buildSuccess)
                    {
                        Log.Logger.Error("Build failed with errors");
                        Environment.ExitCode = 1;
                    }
                    else if (BuildResultStatusHelper.GetBuildResult(GlobalEnv) == PipelineConstants.BuildConstants.BuildUnknownValue)
                    {
                        Log.Logger.Warning("No build status");
                        Environment.ExitCode = -1;
                    }
                    else
                    {
                        Log.Logger.Information("Build was successful");
                        Environment.ExitCode = 0;
                    }
                    break;
                //Post Build Actions will go here:
            }
        }
        
        return pipeline;
    }
}