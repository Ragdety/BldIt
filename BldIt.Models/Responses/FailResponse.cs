using System.Collections.Generic;

namespace BldIt.Models.Responses
{
    public class FailResponse : BaseResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}