using BldIt.Api.Shared.Abstractions;

namespace BldIt.Api.Shared.Exceptions
{
    public class DomainUnauthorizedException : DomainException
    {
        public DomainUnauthorizedException() : this("Must be logged in to access endpoint") { }
        
        public DomainUnauthorizedException(string message) : base(message) {}
    }
}