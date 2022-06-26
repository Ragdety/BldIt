using BldIt.Models.Abstractions;

namespace BldIt.Models.Exceptions
{
    public class DomainValidationException : DomainException
    {
        public string Detail { get; }
        
        public DomainValidationException(string message, string detail) : base(message)
        {
            Detail = detail;
        }
    }
}