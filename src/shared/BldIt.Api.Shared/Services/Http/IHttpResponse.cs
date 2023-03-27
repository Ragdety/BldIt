using System.Net;

namespace BldIt.Api.Shared.Services.Http;

public interface IHttpResponse
{
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }
}