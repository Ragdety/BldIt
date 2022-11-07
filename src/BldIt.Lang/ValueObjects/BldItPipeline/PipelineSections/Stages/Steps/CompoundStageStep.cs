using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.Enums;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

public abstract class CompoundStageStep : StageStep
{
    protected CompoundStepType StepType { get; }
    
    public override string StepIdentifier { get; protected init; } = nameof(CompoundStageStep);
    
    protected CompoundStageStep(CompoundStepType stepType)
    {
        StepType = stepType;
    }
}