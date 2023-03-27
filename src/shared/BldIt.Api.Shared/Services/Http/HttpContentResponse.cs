using System.Net;

namespace BldIt.Api.Shared.Services.Http;

/// <summary>
/// Default implementation of IHttpContentResponse
/// </summary>
/// <typeparam name="TContent">Content that will be returned from http response</typeparam>
/// <typeparam name="TErrorContent">Error content returned by api</typeparam>
public class HttpContentResponse<TContent, TErrorContent> : IHttpContentResponse<TContent, TErrorContent>
{
    public TContent? Content { get; set; }
    
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }

    public TErrorContent? ErrorContent { get; set; }
}