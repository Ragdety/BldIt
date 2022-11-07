using BldIt.Models.Abstractions;

namespace BldIt.Models.Exceptions
{
    public class DomainForbiddenException : DomainException
    {
        public DomainForbiddenException() : this("You are not authorized to access this resource") { }
        public DomainForbiddenException(string message) : base(message) { }
    }
}