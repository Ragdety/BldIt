using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.Enums;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps;

public class EchoStep : SimpleStageStep
{
    public string? Message { get; }
    public override string StepIdentifier { get; protected init; } 
        = nameof(EchoStep).Replace("Step", "").ToLower();

    protected EchoStep(SimpleStepType stepType, string? message) : base(stepType)
    {
        Message = message;
    }

    public EchoStep(string? output)
        : this(SimpleStepType.EchoStep, output) { }

    public override string? ToString()
    {
        return Message;
    }
}