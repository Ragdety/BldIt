namespace BldIt.Lang.Exceptions;

public class MissingVariableException : Exception
{
    public MissingVariableException(string variableName)
        : base($"No such variable: '{variableName}'") { }
}