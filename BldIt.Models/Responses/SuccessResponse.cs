using System.Collections.Generic;

namespace BldIt.Models.Responses
{
    public class SuccessResponse<T> : BaseResponse
    {
        public SuccessResponse() { }

        public SuccessResponse(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }
    }
}