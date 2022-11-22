using BldIt.Api.Shared.Services.Errors;
using BldIt.Api.Shared.Services.Uri;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Api.Shared.Responses.Problems;

public class InstanceNotOwned : ProblemDetails
{
    public InstanceNotOwned(string detail, string instance, UriService uriService)
    {
        Detail = detail;
        Instance = instance;
        Status = StatusCodes.Status400BadRequest;
        Title = ErrorTypeMessages.InstanceNotOwned;
        Type = uriService.GetDocsErrorTypeUri(ErrorTypeMessages.InstanceNotOwned).ToString();
    }
}