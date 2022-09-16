namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.SimpleStageSteps;

public class RunStep : SimpleStageStep
{
    public string Command { get; }
    public string? Arguments { get; }
    public string? WorkingDirectory { get; }
    public int ErrorCode { get; set; }
    public override string StepIdentifier { get; protected init; } 
        = nameof(RunStep).Replace("Step", "").ToLower();

    private RunStep(
        SimpleStepType stepType,
        string command,
        string? arguments,
        string? workingDirectory) : base(stepType)
    {
        Command = command;
        Arguments = arguments;
        WorkingDirectory = workingDirectory;
    }
    
    public RunStep(string command, string? arguments, string? workingDirectory) 
        : this(SimpleStepType.RunStep, command, arguments, workingDirectory)
    {
        Command = command;
        Arguments = arguments;
        WorkingDirectory = workingDirectory;
    }
}