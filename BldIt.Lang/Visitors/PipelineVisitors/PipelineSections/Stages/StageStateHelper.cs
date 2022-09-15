﻿using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps;

namespace BldIt.Lang.Visitors.PipelineVisitors.PipelineSections.Stages;

public static class StageStateHelper
{
    /// <summary>
    /// Sets the stage state to failed if any of the steps have failed
    /// </summary>
    /// <param name="stage">Stage to set the state</param>
    /// <returns></returns>
    public static Stage SetStageFailedBasedOnSteps(Stage stage)
    {
        var steps = stage.Steps;
        foreach (var step in steps)
        {
            if (step is ErrorStep || step.StepIdentifier == "error")
            {
                stage.State = StageState.Failed;
                break;
            }

            if (step is RunStep || step.StepIdentifier == "run")
            {
                var runStep = (RunStep)step;
                if (runStep.ErrorCode == 0) continue;
                stage.State = StageState.Failed;
                break;
            }
        }
        return stage;
    }
}