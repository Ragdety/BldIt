using BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections;

public class ParameterStatement
{
    public HashSet<Parameter> Parameters { get; }

    public ParameterStatement()
    {
        Parameters = new HashSet<Parameter>();
    }
    
    public void AddParameter(Parameter parameter)
    {
        Parameters.Add(parameter);
    }
}