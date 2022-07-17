using BldIt.Lang.ValueObjects.BldItPipeline.PipelineExpressions;

namespace BldIt.Lang.ValueObjects.BldItPipeline;

public class Stage
{
    public List<Step> Steps { get; }
    public Dictionary<string, PipelineExpression> LocalEnv { get; }
    
    public Stage()
    { 
        Steps = new List<Step>();
        LocalEnv = new Dictionary<string, PipelineExpression>();
    }
}