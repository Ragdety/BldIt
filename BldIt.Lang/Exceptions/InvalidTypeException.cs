namespace BldIt.Lang.Exceptions;

public class InvalidTypeException : Exception
{
    public InvalidTypeException(string message) : base(message) { }
}