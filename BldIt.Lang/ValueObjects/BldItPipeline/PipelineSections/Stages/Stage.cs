using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages.Steps;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

public class Stage : PipelineSection
{
    public List<StageStep> StageSteps { get; }
    public string StageName { get; }
    public StageState StageState { get; set; }

    public Stage(string stageName)
    {
        StageSteps = new List<StageStep>();
        StageName = stageName;
    }
}