namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

public abstract class SimpleStageStep : StageStep
{
    protected SimpleStepType StepType { get; }
    
    protected SimpleStageStep(SimpleStepType stepType, string stepIdentifier) : base(stepIdentifier)
    {
        StepType = stepType;
    }
}