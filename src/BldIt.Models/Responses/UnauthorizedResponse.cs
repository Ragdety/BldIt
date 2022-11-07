namespace BldIt.Models.Responses
{
    public class UnauthorizedResponse : BaseResponse
    {
        public string Error { get; set; } = "Unauthorized";
    }
}