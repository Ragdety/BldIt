namespace BldIt.Models.Responses
{
    public class AuthFailedResponse : BaseResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}