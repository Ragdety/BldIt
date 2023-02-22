using BldIt.Api.Shared.Services.Errors;
using BldIt.Api.Shared.Services.Uri;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Api.Shared.Responses.Problems;

public class InvalidCredentials : ProblemDetails
{
    public InvalidCredentials(string detail, string instance, UriService uriService)
    {
        Detail = detail;
        Instance = instance;
        Status = StatusCodes.Status401Unauthorized;
        Title = ErrorTypeMessages.InvalidCredentials;
        Type = uriService.GetDocsErrorTypeUri(ErrorTypeMessages.InvalidCredentials).ToString();
    }
    
    public InvalidCredentials(
        string detail, 
        string instance, 
        UriService uriService, 
        Dictionary<string, object?> extensions) : this(detail, instance, uriService)
    {
        //Invalid credentials may have extensions to provide more information about the invalid credentials
        foreach (var extension in extensions)
        {
            Extensions.Add(extension.Key, extension.Value);
        }
    }
}