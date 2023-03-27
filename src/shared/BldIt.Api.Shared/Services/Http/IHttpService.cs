namespace BldIt.Api.Shared.Services.Http;

public interface IHttpService
{
    /// <summary>
    /// Default request method
    /// </summary>
    /// <param name="requestMessage">Request message sent through the httpClient</param>
    /// <returns>The appropriate http response</returns>
    Task<IHttpResponse> Request(HttpRequestMessage requestMessage);

    /// <summary>
    /// Sends an http request with content or error content
    /// </summary>
    /// <param name="requestMessage">Request message sent through the httpClient</param>
    /// <typeparam name="TContent">Content that will be returned from http response</typeparam>
    /// <typeparam name="TErrorContent">Error content returned by api</typeparam>
    /// <returns>HttpContentResponse with content data or error data from api</returns>
    Task<IHttpContentResponse<TContent, TErrorContent>> RequestWithContent<TContent, TErrorContent>(
        HttpRequestMessage requestMessage) where TContent : class where TErrorContent : class;
}