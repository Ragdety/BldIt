using BldIt.Api.Shared.Interfaces;

namespace BldIt.Identity.Contracts.Responses
{
    public class AuthFailedResponse : IResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public string Message { get; set; }
    }
}