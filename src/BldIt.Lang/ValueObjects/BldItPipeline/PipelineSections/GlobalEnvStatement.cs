using BldIt.Lang.ValueObjects.BldItExpressions;

namespace BldIt.Lang.ValueObjects.BldItPipeline.PipelineSections;

public class GlobalEnvStatement : PipelineSection
{
    public Dictionary<string, Expression> EnvironmentVariables { get; }
    
    public GlobalEnvStatement()
    {
        EnvironmentVariables = new Dictionary<string, Expression>();
    }

    //Might do test cases in the future to check if all variables are added correctly
    public List<string> GetEnvironmentVariableNames() 
        => EnvironmentVariables.Keys.ToList();
    
    public bool SetEnvironmentVariable(string varName, Expression value) 
        => EnvironmentVariables.TryAdd(varName, value);
}