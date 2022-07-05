using BldIt.Models.Abstractions;

namespace BldIt.Models.Exceptions
{
    public class DomainUnauthorizedException : DomainException
    {
        public DomainUnauthorizedException() : this("Must be logged in to access endpoint") { }
        
        public DomainUnauthorizedException(string message) : base(message) {}
    }
}