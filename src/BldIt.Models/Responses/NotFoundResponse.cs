namespace BldIt.Models.Responses
{
    public class NotFoundResponse : BaseResponse
    {
        public string Error { get; set; } = "Not Found";
    }
}