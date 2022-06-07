using System.Collections.Generic;
using BldIt.Models.Responses;

namespace BldIt.Api.Services
{
    public class ResponsesService
    {
        private readonly int _statusCode;
        private readonly string _message;

        public ResponsesService(int statusCode, string message)
        {
            _statusCode = statusCode;
            _message = message;
        }

        public SuccessResponse<T> GenerateSuccessResponse<T>(IEnumerable<T> data)
        {
            return new SuccessResponse<T>
            {
                Data = data,
                StatusCode = _statusCode,
                Message = _message
            };
        }
        
        public FailResponse GenerateFailResponse(IEnumerable<string> errors)
        {
            return new FailResponse
            {
                Errors = errors,
                StatusCode = _statusCode,
                Message = _message
            };
        }
    }
}