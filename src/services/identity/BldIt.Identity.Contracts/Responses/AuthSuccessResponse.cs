using BldIt.Api.Shared.Interfaces;

namespace BldIt.Identity.Contracts.Responses
{
    public class AuthSuccessResponse : IResponse
    {
        public string Token { get; set; }
        public Guid RefreshToken { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Message { get; set; }
    }
}