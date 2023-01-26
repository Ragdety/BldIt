using BldIt.Api.Shared.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Files.Api.Controllers;

public class FileController : ApiController
{
    public FileController()
    {
        
    }
    
    [HttpGet("RouteHere")]
    public Task<IActionResult> GetBuildLogFile()
    {
        throw new NotImplementedException();
    }
}