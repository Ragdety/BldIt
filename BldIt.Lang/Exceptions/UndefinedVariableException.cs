namespace BldIt.Lang.Exceptions;

public class UndefinedVariableException : Exception
{
    public UndefinedVariableException(string variableName)
        : base($"No such variable: '{variableName}'") { }
}