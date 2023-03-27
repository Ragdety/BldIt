using System.Net;

namespace BldIt.Api.Shared.Services.Http;

/// <summary>
/// Default implementation of IHttpResponse
/// </summary>
public class HttpResponse : IHttpResponse
{
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }
}