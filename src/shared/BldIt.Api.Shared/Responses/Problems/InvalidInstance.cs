using BldIt.Api.Shared.Services.Errors;
using BldIt.Api.Shared.Services.Uri;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Api.Shared.Responses.Problems;

public class InvalidInstance : ProblemDetails
{
    public InvalidInstance(
        string detail, 
        string instance, 
        UriService uriService)
    {
        Detail = detail;
        Instance = instance;
        Status = StatusCodes.Status400BadRequest;
        Title = ErrorTypeMessages.InvalidInstance;
        Type = uriService.GetDocsErrorTypeUri(ErrorTypeMessages.InvalidInstance).ToString();
    }

    public InvalidInstance(
        string detail, 
        string instance, 
        UriService uriService, 
        Dictionary<string, object?> extensions) : this(detail, instance, uriService)
    {
        //Invalid instance may have extensions to provide more information about the invalid instance
        foreach (var extension in extensions)
        {
            Extensions.Add(extension.Key, extension.Value);
        }
    }
}