namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps;

public class EchoStep : SimpleStageStep
{
    public string StepIdentifier { get; }
    public string? Output { get; }

    private EchoStep(SimpleStepType stepType, string stepIdentifier, string? output) : base(stepType, stepIdentifier)
    {
        StepIdentifier = stepIdentifier;
        Output = output;
    }
    
    public EchoStep(string stepIdentifier, string? output) 
        : this(SimpleStepType.EchoStep, stepIdentifier, output) { }
}