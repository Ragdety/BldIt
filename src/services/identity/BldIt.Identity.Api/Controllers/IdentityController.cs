using System.Globalization;
using BldIt.Api.Shared;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Identity.Contracts.Dtos;
using BldIt.Identity.Contracts.Responses;
using BldIt.Identity.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Identity.Service.Controllers
{
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityManager _identityManager;
        private readonly ILogger<IdentityController> _logger;
        private readonly UriService _uriService;

        public IdentityController(
            IIdentityManager identityManager, 
            ILogger<IdentityController> logger, 
            UriService uriService)
        {
            _identityManager = identityManager;
            _logger = logger;
            _uriService = uriService;
        }

        [HttpPost(Routes.Identity.Register)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto userToRegister)
        {
            if (!ModelState.IsValid)
            {
                var problems = new InvalidInstance(
                    "Errors while registering.", 
                    Routes.Identity.Register, 
                    _uriService);

                var errors =
                    ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage));
                
                problems.Extensions.Add("Errors", errors);
                throw new ProblemDetailsException(problems);
            }
            
            var authResponse = await _identityManager.RegisterAsync(userToRegister);

            if (!authResponse.Success)
            {
                var problems = new InvalidInstance(
                    "Errors while registering.", 
                    Routes.Identity.Register, 
                    _uriService);
                
                problems.Extensions.Add("Errors", authResponse.Errors);
                throw new ProblemDetailsException(problems);
            }
            
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                ValidTo = authResponse.ValidTo,
                Message = "Successfully Registered!"
            });
        }
        
        [HttpPost(Routes.Identity.Login)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserDto userToLogin)
        {
            var authResponse = await _identityManager.LoginAsync(userToLogin);

            if (!authResponse.Success)
            {
                var problems = new InvalidInstance(
                    "Errors while logging in.", 
                    Routes.Identity.Register, 
                    _uriService);
                
                problems.Extensions.Add("Errors", authResponse.Errors);
                throw new ProblemDetailsException(problems);
            }

            _logger.LogDebug("Now: {S}", DateTime.UtcNow.ToLocalTime().ToString(CultureInfo.InvariantCulture));
            _logger.LogDebug("JWT is validTo: {S}", authResponse.ValidTo.ToString(CultureInfo.InvariantCulture));
            
            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                ValidFrom = authResponse.ValidFrom,
                ValidTo = authResponse.ValidTo,
                Message = "Successfully Logged In!"
            });
        }
    }
}