namespace BldIt.Lang.Exceptions;

public class UndefinedStageException : UndefinedException
{
    public UndefinedStageException(string stageName)
        : base($"Stage '{stageName}' is not defined") { }
}