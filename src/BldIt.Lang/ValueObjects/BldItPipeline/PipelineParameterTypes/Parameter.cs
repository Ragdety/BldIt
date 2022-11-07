using BldIt.Lang.ValueObjects.BldItExpressions.ConstantTypes;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineParameterTypes;

public class Parameter
{
    public ParameterType ParameterType { get; }
    public string ParameterName { get; }
    public object? ParameterValue { get; }

    public virtual Type Type
    {
        get
        {
            return ParameterType switch
            {
                ParameterType.BoolParam => typeof(BoolValue),
                ParameterType.StringParam => typeof(StringValue),
                _ => GetType()
            };
        }
    }

    public Parameter(
        ParameterType parameterType, 
        string parameterName, 
        object? parameterValue)
    {
        ParameterType = parameterType;
        ParameterName = parameterName;
        ParameterValue = parameterValue;
    }
}