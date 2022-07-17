namespace BldIt.Lang.Exceptions;

public class UndefinedVariableException : UndefinedException
{
    public UndefinedVariableException(string variableName)
        : base($"Variable '{variableName}' is not defined") { }
}