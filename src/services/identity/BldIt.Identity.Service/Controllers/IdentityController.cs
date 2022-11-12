using BldIt.Api.Shared;
using BldIt.Identity.Contracts.Dtos;
using BldIt.Identity.Contracts.Responses;
using BldIt.Identity.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Identity.Service.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(
            IIdentityRepository identityRepository, 
            ILogger<IdentityController> logger)
        {
            _identityRepository = identityRepository;
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
            
            var authResponse = await _identityRepository.RegisterAsync(userToRegister);

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
            var authResponse = await _identityRepository.LoginAsync(userToLogin);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Message = "Errors while logging in.",
                    Errors = authResponse.Errors
                });
            }

            //_logger.LogInformation("Now: {0}", DateTime.UtcNow.ToLocalTime().ToString());
            //_logger.LogInformation("JWT is validTo: {0}", authResponse.ValidTo.ToString());
            
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