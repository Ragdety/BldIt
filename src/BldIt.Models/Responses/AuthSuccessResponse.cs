namespace BldIt.Models.Responses
{
    public class AuthSuccessResponse : BaseResponse
    {
        public string Token { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}