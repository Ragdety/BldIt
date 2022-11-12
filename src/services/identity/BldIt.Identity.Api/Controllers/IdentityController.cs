using System.Globalization;
using BldIt.Api.Shared;
using BldIt.Identity.Contracts.Dtos;
using BldIt.Identity.Contracts.Responses;
using BldIt.Identity.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Identity.Service.Controllers
{
    [ApiController]
    public class IdentityController : Controller
    {
        private readonly IIdentityManager _identityManager;
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(
            IIdentityManager identityManager, 
            ILogger<IdentityController> logger)
        {
            _identityManager = identityManager;
            _logger = logger;
        }

        [HttpPost(Routes.Identity.Register)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto userToRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Message = "Errors while registering.",
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage))
                });
            }
            
            var authResponse = await _identityManager.RegisterAsync(userToRegister);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Message = "Errors while registering.",
                    Errors = authResponse.Errors
                });
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
                return BadRequest(new AuthFailedResponse
                {
                    Message = "Errors while logging in.",
                    Errors = authResponse.Errors
                });
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