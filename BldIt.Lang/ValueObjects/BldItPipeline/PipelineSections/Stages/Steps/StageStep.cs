﻿namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

public abstract class StageStep
{
    //A stage step can be a script block, or a pipeline function call (such as bat/shell/error)
    
    public string StepIdentifier { get; }
    
    protected StageStep(string stepIdentifier)
    {
        StepIdentifier = stepIdentifier;
    }
}