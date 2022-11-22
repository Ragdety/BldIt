using BldIt.Api.Shared.Services.Errors;
using BldIt.Api.Shared.Services.Uri;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Api.Shared.Responses.Problems;

public class InstanceNotFound : ProblemDetails
{
    public InstanceNotFound(string detail, string instance, UriService uriService)
    {
        Detail = detail;
        Instance = instance;
        Status = StatusCodes.Status404NotFound;
        Title = ErrorTypeMessages.InstanceNotFound;
        Type = uriService.GetDocsErrorTypeUri(ErrorTypeMessages.InstanceNotFound).ToString();
    }
}