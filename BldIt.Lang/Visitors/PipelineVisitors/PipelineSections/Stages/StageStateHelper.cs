using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.CompoundStageSteps;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps.Enums;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages;

public static class StageStateHelper
{
    /// <summary>
    /// Sets the stage state to failed if any of the steps have failed
    /// </summary>
    /// <param name="stage">Stage to set the state</param>
    /// <returns></returns>
    public static Stage SetStageFailedBasedOnHandleErrorStep(Stage stage)
    {
        foreach (var step in stage.Steps)
        {
            if (step.StepIdentifier == "handleError")
            {
                var handleErrorStep = (HandleErrorStep) step;

                //If stage result is set to success in handleError step,
                //set stage as success regardless of steps' status
                if (handleErrorStep.DesiredStageResult == "SUCCESS")
                {
                    stage.State = StageState.Success;
                    
                    //Keep checking for other steps after handleError (if any)
                    //After handleErrorStep, any step with error will override the stage state,
                    //since step is not inside handleErrorStep
                    continue;
                }
                
                //Otherwise, check if any step inside handleError step has failed
                foreach (var stepWithErrorHandling in handleErrorStep.StepsWithErrorHandling)
                {
                    if (StepHasFailed(stepWithErrorHandling))
                    {
                        handleErrorStep.ErrorCaught = true;
                        //handleErrorStep.StageResult is set when visiting handleErrorStep
                        stage.State = handleErrorStep.DesiredStageResult switch
                        {
                            "FAILURE" => StageState.Failure,
                            "UNSTABLE" => StageState.Unstable,
                            "SUCCESS" => StageState.Success,
                            _ => throw new ArgumentOutOfRangeException()
                        };
                    }
                    else
                    {
                        stage.State = StageState.Success;
                    }
                }
                //We should continue to not override above's result
                continue;
            }

            if (StepHasFailed(step))
            {
                Environment.Exit(-255);
                break;
            }

            stage.State = StageState.Success;
        }
        return stage;
    }
    
    private static bool StepHasFailed(StageStep step)
    {
        switch (step.StepIdentifier)
        {
            case "error":
                return true;
            case "run":
            {
                var runStep = (RunStep)step;
                return runStep.Status != RunStepStatus.Success;
            }
            case "handleError":
            {
                var handleErrorStep = (HandleErrorStep)step;
                
                //If the desired stage result is success, then we can assume no step has failed
                if (handleErrorStep.DesiredStageResult == "SUCCESS") return false;
                
                //Check if any other step has failed
                return handleErrorStep.StepsWithErrorHandling.Any(StepHasFailed);
            }
            default:
                return false;
        }
    }
}