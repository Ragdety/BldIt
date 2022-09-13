namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

public abstract class CompoundStageStep : StageStep
{
    protected CompoundStepType StepType { get; }
    
    protected CompoundStageStep(CompoundStepType stepType, string stepIdentifier) : base(stepIdentifier)
    {
        StepType = stepType;
    }
}