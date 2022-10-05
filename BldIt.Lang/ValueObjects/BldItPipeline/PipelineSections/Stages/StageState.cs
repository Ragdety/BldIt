namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

public enum StageState
{
    NotStarted,
    Running,
    Success,
    Unstable,
    Failure,
    Cancelled
}