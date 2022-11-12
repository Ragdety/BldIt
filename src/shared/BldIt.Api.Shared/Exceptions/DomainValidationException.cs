using BldIt.Api.Shared.Abstractions;

namespace BldIt.Api.Shared.Exceptions
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