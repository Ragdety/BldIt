using System.Globalization;
using BldIt.Api.Shared;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Auth.Utilities;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Api.Shared.Settings;
using BldIt.Identity.Contracts.Dtos;
using BldIt.Identity.Contracts.Responses;
using BldIt.Identity.Contracts.Results;
using BldIt.Identity.Core.Interfaces;
using BldIt.Identity.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Identity.Service.Controllers;

public class IdentityController : ApiController
{
    private readonly IIdentityManager _identityManager;
    private readonly ILogger<IdentityController> _logger;
    private readonly UriService _uriService;
    private readonly JwtSettings _jwtSettings;
    private readonly IRepository<RefreshToken, Guid> _refreshTokenRepository;
    private readonly IWebHostEnvironment _env;

    public IdentityController(
        IIdentityManager identityManager, 
        ILogger<IdentityController> logger, 
        UriService uriService, 
        JwtSettings jwtSettings, 
        IRepository<RefreshToken, Guid> refreshTokenRepository, 
        IWebHostEnvironment env)
    {
        _identityManager = identityManager;
        _logger = logger;
        _uriService = uriService;
        _jwtSettings = jwtSettings;
        _refreshTokenRepository = refreshTokenRepository;
        _env = env;
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
            throw ProblemDetailsEx(authResponse, Routes.Identity.Register);
        }
        
        SetAuthCookies(authResponse.RefreshToken);
            
        return Ok(new AuthSuccessResponse
        {
            Token = authResponse.Token,
            ValidFrom = authResponse.ValidFrom,
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
            throw ProblemDetailsEx(authResponse, Routes.Identity.Login);
        }

        _logger.LogDebug("Now: {S}", DateTime.UtcNow.ToLocalTime().ToString(CultureInfo.InvariantCulture));
        _logger.LogDebug("JWT is validTo: {S}", authResponse.ValidTo.ToString(CultureInfo.InvariantCulture));

        SetAuthCookies(authResponse.RefreshToken);

        return Ok(new AuthSuccessResponse
        {
            Token = authResponse.Token,
            ValidFrom = authResponse.ValidFrom,
            ValidTo = authResponse.ValidTo,
            Message = "Successfully Logged In!"
        });
    }
    
    [HttpGet(Routes.Identity.Refresh)]
    public async Task<IActionResult> RefreshAsync()
    {
        var cookies = HttpContext.Request.Cookies;
        var refreshToken = cookies[RefreshTokenUtilities.CookieName];
        
         if (refreshToken is null)
         {
             var problems = new InvalidCredentials(
                 "Errors while refreshing token.", 
                 Routes.Identity.Refresh, 
                 _uriService);
                 
             problems.Extensions.Add("Errors", "No refresh token found in cookies.");
             throw new ProblemDetailsException(problems);
         }

         var refreshTokenModel =
             await _refreshTokenRepository.GetAsync(Guid.Parse(refreshToken));

         var refreshTokenDto = new RefreshTokenDto
         {
             RefreshToken = Guid.Parse(cookies[RefreshTokenUtilities.CookieName]!),
             Token = refreshTokenModel.JwtValue
         };

        var authResponse = await _identityManager.RefreshTokenAsync(refreshTokenDto);

        if (!authResponse.Success)
        {
            throw ProblemDetailsEx(authResponse, Routes.Identity.Refresh);
        }

        _logger.LogDebug("Now: {S}", DateTime.UtcNow.ToLocalTime().ToString(CultureInfo.InvariantCulture));
        _logger.LogDebug("JWT is validTo: {S}", authResponse.ValidTo.ToString(CultureInfo.InvariantCulture));
        
        SetAuthCookies(authResponse.RefreshToken);
            
        return Ok(new AuthSuccessResponse
        {
            Token = authResponse.Token,
            ValidFrom = authResponse.ValidFrom,
            ValidTo = authResponse.ValidTo,
            Message = "Successfully Refreshed Token!"
        });
    }
    
    [HttpGet(Routes.Identity.Logout)]
    public async Task<IActionResult> LogoutAsync()
    {
        var cookies = HttpContext.Request.Cookies;
        var refreshToken = cookies[RefreshTokenUtilities.CookieName];
        
        //If no refresh token (cookie expired) then good! Just return no content 
        if (refreshToken is null) return NoContent();

        var refreshTokenModel =
            await _refreshTokenRepository.GetAsync(Guid.Parse(refreshToken));

        if (refreshTokenModel is null)
        {
            DeleteAuthCookies();
            return NoContent();
        }

        //Delete the refresh token from the database
        await _refreshTokenRepository.RemoveAsync(refreshTokenModel.Id);
        DeleteAuthCookies();

        return NoContent();
    }
    
    private CookieOptions GetCookieOptions()
    {
        if (_env.IsProduction())
        {
            return new CookieOptions
            {
                Expires = RefreshTokenUtilities.GetRefreshTokenExpiryDate(),
                HttpOnly = true,
                //Serves on https only
                Secure = true
            };
        }
        
        return new CookieOptions
        {
            Expires = RefreshTokenUtilities.GetRefreshTokenExpiryDate(),
            HttpOnly = true
        };
    }
    
    private void SetAuthCookies(Guid refreshToken)
    {
        //Setting the jwt HttpOnly cookie
        Response.Cookies.Append(RefreshTokenUtilities.CookieName, 
            refreshToken.ToString(), GetCookieOptions());
    }
    
    private void DeleteAuthCookies()
    {
        Response.Cookies.Delete(RefreshTokenUtilities.CookieName, GetCookieOptions());
    }

    private ProblemDetailsException ProblemDetailsEx(AuthenticationResult result, string instance)
    {
        ProblemDetails problem = result.ErrorCode switch
        {
            401 => new InvalidCredentials("Errors while authenticating.", instance, _uriService),
            _ => new InvalidInstance("Errors while authenticating.", instance, _uriService)
        };

        problem.Extensions.Add("Errors", result.Errors);
        return new ProblemDetailsException(problem);
    }
}