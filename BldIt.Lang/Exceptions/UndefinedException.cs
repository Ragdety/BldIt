namespace BldIt.Lang.Exceptions;

public abstract class UndefinedException : Exception
{
    protected UndefinedException(string message) : base(message)
    {
    }
}