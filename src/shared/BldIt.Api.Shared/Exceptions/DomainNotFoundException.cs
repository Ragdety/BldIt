using BldIt.Api.Shared.Abstractions;

namespace BldIt.Api.Shared.Exceptions
{
    public class DomainNotFoundException : DomainException
    {
        public DomainNotFoundException(string message) : base(message)
        {
        }
    }
}