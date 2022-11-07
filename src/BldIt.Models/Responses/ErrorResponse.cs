namespace BldIt.Models.Responses
{
    public class ErrorResponse : BaseResponse
    {
        public List<ErrorModel> Errors { get; set; } = new();
    }
}