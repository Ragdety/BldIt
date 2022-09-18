using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.Enums;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps;

public class ErrorStep : EchoStep
{
    public override string StepIdentifier { get; protected init; } 
        = nameof(ErrorStep).Replace("Step", "").ToLower();

    private ErrorStep(SimpleStepType stepType, string? message)
        : base(stepType, message)
    {
        
    }

    public ErrorStep(string? output)
        : this(SimpleStepType.ErrorStep, output) { }
}