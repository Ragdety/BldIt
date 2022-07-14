namespace BldIt.Lang.Exceptions;

public class InvalidDataTypeException : Exception
{
    public InvalidDataTypeException(string message) : base(message) { }
}