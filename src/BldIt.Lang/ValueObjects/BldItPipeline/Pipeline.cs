using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

namespace BldIt.Lang.ValueObjects.BldItPipeline;

public class Pipeline
{
    public GlobalEnvStatement GlobalEnvStatement { get; set; }

    public ParameterStatement ParameterStatement { get; set; }

    public StagesStatement StagesStatement { get; set; }
    
    //Post actions class here later
    
    public Pipeline()
    {
        GlobalEnvStatement = new GlobalEnvStatement();
        ParameterStatement = new ParameterStatement();
        StagesStatement = new StagesStatement();
    }
    
    public void SetGlobalEnv(GlobalEnvStatement globalEnvStatement)
    {
        GlobalEnvStatement = globalEnvStatement;
    }
    
    public void SetParameterStatement(ParameterStatement parameterStatement)
    {
        ParameterStatement = parameterStatement;
    }
    
    public void SetStageStatement(StagesStatement stagesStatement)
    {
        StagesStatement = stagesStatement;
    }
}