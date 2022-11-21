using BldIt.Api.Shared.Services.Uri;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Api.Shared.Services.Errors;

public static class ProblemDetailsHelper
{
    public static ProblemDetails InstanceNotFound(string detail, string instance, UriService uriService)
    {
        return new ProblemDetails
        {
            Detail = detail,
            Instance = instance,
            Status = StatusCodes.Status404NotFound,
            Title = ErrorTypeMessages.InstanceNotFound,
            Type = uriService.GetDocsErrorTypeUri(ErrorTypeMessages.InstanceNotFound).ToString()
        };
    }
    
    public static ProblemDetails InvalidInstance(
        string detail, 
        string instance, 
        UriService uriService, 
        Dictionary<string, object?>? extensions = null)
    {
        var problemDetails = new ProblemDetails
        {
            Detail = detail,
            Instance = instance,
            Status = StatusCodes.Status400BadRequest,
            Title = ErrorTypeMessages.InvalidInstance,
            Type = uriService.GetDocsErrorTypeUri(ErrorTypeMessages.InvalidInstance).ToString(),
        };

        if (extensions == null) return problemDetails;
        
        //Invalid instance may have extensions to provide more information
        foreach (var extension in extensions)
        {
            problemDetails.Extensions.Add(extension.Key, extension.Value);
        }

        return problemDetails;
    }
    
    public static ProblemDetails ExistingInstance(string detail, string instance, UriService uriService)
    {
        return new ProblemDetails
        {
            Detail = detail,
            Instance = instance,
            Status = StatusCodes.Status400BadRequest,
            Title = ErrorTypeMessages.ExistingInstance,
            Type = uriService.GetDocsErrorTypeUri(ErrorTypeMessages.ExistingInstance).ToString()
        };
    }
    
    public static ProblemDetails InstanceNotOwned(string detail, string instance, UriService uriService)
    {
        return new ProblemDetails
        {
            Detail = detail,
            Instance = instance,
            Status = StatusCodes.Status400BadRequest,
            Title = ErrorTypeMessages.InstanceNotOwned,
            Type = uriService.GetDocsErrorTypeUri(ErrorTypeMessages.InstanceNotOwned).ToString()
        };
    }
    
    public static ProblemDetails InvalidCredentials(string detail, string instance, UriService uriService)
    {
        return new ProblemDetails
        {
            Detail = detail,
            Instance = instance,
            Status = StatusCodes.Status401Unauthorized,
            Title = ErrorTypeMessages.InvalidCredentials,
            Type = uriService.GetDocsErrorTypeUri(ErrorTypeMessages.InvalidCredentials).ToString()
        };
    }
    
    public static ProblemDetails InvalidToken(string detail, string instance, UriService uriService)
    {
        return new ProblemDetails
        {
            Detail = detail,
            Instance = instance,
            Status = StatusCodes.Status400BadRequest,
            Title = ErrorTypeMessages.InvalidToken,
            Type = uriService.GetDocsErrorTypeUri(ErrorTypeMessages.InvalidToken).ToString()
        };
    }
}