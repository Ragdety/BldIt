using BldIt.Api.Shared.Abstractions;

namespace BldIt.Api.Shared.Exceptions
{
    public class DomainForbiddenException : DomainException
    {
        public DomainForbiddenException() : this("You are not authorized to access this resource") { }
        public DomainForbiddenException(string message) : base(message) { }
    }
}