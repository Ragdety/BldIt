namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

public enum StageState
{
    NotStarted,
    Running,
    Completed,
    Failed,
    Cancelled
}