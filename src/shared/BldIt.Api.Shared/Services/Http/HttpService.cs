using Newtonsoft.Json;

namespace BldIt.Api.Shared.Services.Http;

public class HttpService : IHttpService
{
    protected readonly HttpClient HttpClient;
    
    public HttpService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }
    
    /// <inheritdoc cref="IHttpService"/>
    public virtual async Task<IHttpResponse> Request(HttpRequestMessage requestMessage)
    {
        var response = await HttpClient.SendAsync(requestMessage);

        var httpResponse = new HttpResponse
        {
            Success = false,
            StatusCode = response.StatusCode,
            Message = response.ReasonPhrase ?? "Request failed"
        };
        
        if (!response.IsSuccessStatusCode)
        {
            return httpResponse;
        }
        
        httpResponse.Success = true;
        httpResponse.Message = "Request was successful";

        return httpResponse;
    }

    /// <inheritdoc cref="IHttpService"/>
    public virtual async Task<IHttpContentResponse<TContent, TErrorContent>> RequestWithContent<TContent, TErrorContent>(
        HttpRequestMessage requestMessage) where TContent : class where TErrorContent : class 
    {
        var response = await HttpClient.SendAsync(requestMessage);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            //Parse error content into TErrorContent object specified by user
            //This will depend on the api, the user will have to know what the error content looks like
            //and create their model accordingly
            var errorObject = JsonConvert.DeserializeObject<TErrorContent>(responseContent);
            return new HttpContentResponse<TContent, TErrorContent>
            {
                Content = null,
                Success = false,
                StatusCode = response.StatusCode,
                Message = response.ReasonPhrase ?? "Request failed",
                ErrorContent = errorObject
            };
        }
        
        //Same as the error content, the user will have to know what the content looks like
        var data = JsonConvert.DeserializeObject<TContent>(responseContent);

        return new HttpContentResponse<TContent, TErrorContent>
        {
            Content = data,
            Success = true,
            StatusCode = response.StatusCode,
            Message = "Request was successful",
            ErrorContent = null
        };
    }

    /// <inheritdoc cref="IHttpService"/>
    public virtual async Task<HttpResponseMessage> RequestWithResponse(HttpRequestMessage requestMessage) 
        => await HttpClient.SendAsync(requestMessage);
}