using BldIt.Models.Abstractions;

namespace BldIt.Models.Exceptions
{
    public class DomainNotFoundException : DomainException
    {
        public DomainNotFoundException(string message) : base(message)
        {
        }
    }
}