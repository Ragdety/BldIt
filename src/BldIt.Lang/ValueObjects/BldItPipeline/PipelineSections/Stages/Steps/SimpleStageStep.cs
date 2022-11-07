using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.Enums;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

public abstract class SimpleStageStep : StageStep
{
    protected SimpleStepType StepType { get; }

    public override string StepIdentifier { get; protected init; } = nameof(SimpleStageStep);

    protected SimpleStageStep(SimpleStepType stepType)
    {
        StepType = stepType;
    }
}