namespace BldIt.Lang.Exceptions;

public class UndefinedEnvironmentVariableException : UndefinedException
{
    public UndefinedEnvironmentVariableException(string envVarName)
        : base($"Environment Variable '{envVarName}' is not defined") { }
}