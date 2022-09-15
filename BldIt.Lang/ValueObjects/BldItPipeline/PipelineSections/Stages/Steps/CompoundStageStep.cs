namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

public abstract class CompoundStageStep : StageStep
{
    protected CompoundStepType StepType { get; }
    
    protected CompoundStageStep(CompoundStepType stepType)
    {
        StepType = stepType;
        StepIdentifier = nameof(CompoundStageStep);
    }
}