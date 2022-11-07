namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

public class StagesStatement
{
    public HashSet<Stage> Stages { get; }

    public StagesStatement()
    {
        Stages = new HashSet<Stage>();
    }
    
    public void AddStage(Stage stage)
    {
        Stages.Add(stage);
    }
}