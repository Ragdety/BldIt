using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.Enums;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps.CompoundStageSteps;

public class HandleErrorStep : CompoundStageStep
{
    public string DesiredBuildResult { get; set; } = "FAILURE";
    public string DesiredStageResult { get; set; } = "SUCCESS";
    public HashSet<StageStep> StepsWithErrorHandling { get; }

    /// <summary>
    /// True if any of the steps failed.
    /// This means, an error was caught.
    /// By default, it is false
    /// </summary>
    public bool ErrorCaught { get; set; }

    private HandleErrorStep(CompoundStepType stepType) : base(stepType)
    {
        StepsWithErrorHandling = new HashSet<StageStep>();
    }

    public HandleErrorStep() : this(CompoundStepType.HandleErrorStep)
    {
        ErrorCaught = false;
    }
    
    public void AddStepWithErrorHandling(StageStep step)
    {
        StepsWithErrorHandling.Add(step);
    }
}