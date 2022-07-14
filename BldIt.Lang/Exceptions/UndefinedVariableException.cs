namespace BldIt.Lang.Exceptions;

public class UndefinedVariableException : ArgumentNullException
{
    public UndefinedVariableException(string variableName)
        : base($"No such variable: '{variableName}'") { }
}