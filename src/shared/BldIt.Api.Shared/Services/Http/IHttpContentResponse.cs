using System.Net;

namespace BldIt.Api.Shared.Services.Http;

public interface IHttpContentResponse<TContent, TErrorContent> : IHttpResponse
{
    public TContent? Content { get; set; }
    
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }

    public TErrorContent? ErrorContent { get; set; }
}