namespace BldIt.Lang.Exceptions;

public class UndefinedFunctionException : UndefinedException
{
    public UndefinedFunctionException(string functionName) 
        : base($"Function: '{functionName}' is not defined") { }
}