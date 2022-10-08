using BldIt.Lang.Exceptions;
using BldIt.Lang.Grammar;
using BldIt.Lang.ValueObjects.BldItExpressions;
using BldIt.Lang.ValueObjects.BldItPipeline;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;
using BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages.Steps;
using Serilog;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages;

public class StageStatementVisitor : BldItParserBaseVisitor<Stage>
{
    protected List<string> SemanticErrors { get; }
    protected Dictionary<string, Expression> GlobalVariables { get; }
    protected Dictionary<string, Func<Expression?[], Expression?>> Functions { get; }
    protected Dictionary<string, Expression> GlobalEnv { get; set; }
    protected HashSet<Parameter> Parameters { get; }

    public StageStatementVisitor(
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

    public override Stage VisitStageBlock(BldItParser.StageBlockContext context)
    {
        var stepsStatements = context.stepStatement();
        var stageStepsStatementVisitor = new StepStatementVisitor(SemanticErrors, GlobalVariables, Functions, GlobalEnv, Parameters);
        var stageName = context.parent.GetChild(1).GetText();
        var stage = new Stage(stageName);

        //If only one simpleStep statement is available:
        if (context.simpleStepStatement() is { } simpleStepStatement)
        {
            stage.State = StageState.Running;
            var step = stageStepsStatementVisitor.VisitSimpleStepStatement(simpleStepStatement);
            stage.Steps.Add(step);

            
            stage = StageStateHelper.SetStageFailedBasedOnHandleErrorStep(stage);
            GlobalEnv = BuildResultStatusHelper.CheckAndSetBuildResultBasedOnHandleErrorStep(GlobalEnv, stage);
            Log.Logger.Debug("Build Result: {BuildResult}", GlobalEnv["BUILD_RESULT"].ToString());
            return stage;
        }

        //If multiple simpleStep statements are available, loop through them:
        if (context.stepStatement() is {} stepStatements)
        {
            stage.State = StageState.Running;
            foreach (var stepStatement in stepStatements)
            {
                var step = stageStepsStatementVisitor.VisitStepStatement(stepStatement);
                stage.Steps.Add(step);
            }

            //Assumes build was successful, this will be changed below if a step fails.
            //GlobalEnv = BuildResultStatusHelper.SetBuildResult(GlobalEnv, PipelineConstants.BuildConstants.BuildSuccessValue);
            
            //This should ideally check only handleError steps, since any other stage will exit the program immediately
            stage = StageStateHelper.SetStageFailedBasedOnHandleErrorStep(stage);
            GlobalEnv = BuildResultStatusHelper.CheckAndSetBuildResultBasedOnHandleErrorStep(GlobalEnv, stage);
            Log.Logger.Debug("Build Result: {BuildResult}", GlobalEnv["BUILD_RESULT"].ToString());
            return stage;
        }

        throw new CompilingException($"Invalid steps statement: {stepsStatements}");
    }
}