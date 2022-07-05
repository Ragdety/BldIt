using System;
using System.Linq;
using System.Security.Claims;
using BldIt.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected string UserId => GetClaim("id");
        protected string Username => GetClaim(ClaimTypes.Name);
        //protected string? Role => GetClaim(BldItConstraints.Claims.Role);

        private string GetClaim(string claimType) => User.Claims
            .FirstOrDefault(x => x.Type.Equals(claimType))?.Value ?? throw new DomainUnauthorizedException();
    }
}