namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

public class StageStatement
{
    public HashSet<Stage> Stages { get; set; }

    public StageStatement()
    {
        Stages = new HashSet<Stage>();
    }
    
    public void AddStage(Stage stage)
    {
        Stages.Add(stage);
    }
}