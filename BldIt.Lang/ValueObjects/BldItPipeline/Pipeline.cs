using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections;
using BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections.Stages;

namespace BldIt.Lang.ValueObjects.BldItPipeline;

public class Pipeline
{
    public GlobalEnvStatement GlobalEnvStatement { get; set; }

    public ParameterStatement ParameterStatement { get; set; }

    public StageStatement StageStatement { get; set; }
    
    //Post actions class here later
    
    public Pipeline()
    {
        GlobalEnvStatement = new GlobalEnvStatement();
        ParameterStatement = new ParameterStatement();
        StageStatement = new StageStatement();
    }
    
    public void SetGlobalEnv(GlobalEnvStatement globalEnvStatement)
    {
        GlobalEnvStatement = globalEnvStatement;
    }
    
    public void SetParameterStatement(ParameterStatement parameterStatement)
    {
        ParameterStatement = parameterStatement;
    }
    
    public void SetStageStatement(StageStatement stageStatement)
    {
        StageStatement = stageStatement;
    }
}