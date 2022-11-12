using System.Security.Claims;
using BldIt.Api.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Api.Shared.Abstractions
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected string UserId => GetClaim("id");
        protected string Username => GetClaim(ClaimTypes.Name);
        protected string? Role => GetClaim(BldItApiConstraints.Claims.Role);

        private string GetClaim(string claimType) => User.Claims
            .FirstOrDefault(x => x.Type.Equals(claimType))?.Value ?? throw new DomainUnauthorizedException();
    }
}