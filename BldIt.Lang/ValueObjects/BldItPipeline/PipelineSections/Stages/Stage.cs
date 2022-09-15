using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

public class Stage : PipelineSection
{
    public List<StageStep> Steps { get; }
    public string Name { get; }
    public StageState State { get; set; }

    public Stage(string name)
    {
        Steps = new List<StageStep>();
        Name = name;
        State = StageState.NotStarted;
    }
}