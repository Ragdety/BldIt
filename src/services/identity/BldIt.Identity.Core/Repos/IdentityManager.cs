using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Services.Auth.Utilities;
using BldIt.Api.Shared.Settings;
using BldIt.Identity.Contracts.Dtos;
using BldIt.Identity.Contracts.Results;
using BldIt.Identity.Core.Helpers;
using BldIt.Identity.Core.Interfaces;
using BldIt.Identity.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BldIt.Identity.Core.Repos;

/// <summary>
/// Manages authentication for a specific user.
/// This is NOT a generic repo since it only handles registration and authentication.
/// </summary>
public class IdentityManager : IIdentityManager
{
    //We can directly use UserManager since we injected it
    private readonly UserManager<User> _userManager;
    private readonly JwtSettings _jwtSettings;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly IRepository<RefreshToken, Guid> _refreshTokenRepository;
    private readonly ILogger<IdentityManager> _logger;

    public IdentityManager(
        UserManager<User> userManager, 
        JwtSettings jwtSettings, 
        TokenValidationParameters tokenValidationParameters, 
        IRepository<RefreshToken, Guid> refreshTokenRepository, 
        ILogger<IdentityManager> logger)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings;
        _tokenValidationParameters = tokenValidationParameters;
        _refreshTokenRepository = refreshTokenRepository;
        _logger = logger;
    }
        
    public async Task<AuthenticationResult> RegisterAsync(RegisterUserDto userToRegister)
    {
        var existingUser = await _userManager.FindByEmailAsync(userToRegister.Email);
        if (existingUser != null)
        {
            return new AuthenticationResult
            {
                Errors = new[] {"User with this email address already exists"},
                ErrorCode = 400
            };
        }
            
        existingUser = await _userManager.FindByNameAsync(userToRegister.UserName);
        if (existingUser != null)
        {
            return new AuthenticationResult
            {
                Errors = new[] {"User with this username already exists"},
                ErrorCode = 400
            };
        }

        //Will use automapper to reduce lines
        var newUser = new User
        {
            FirstName = userToRegister.FirstName,
            LastName = userToRegister.LastName,
            UserName = userToRegister.UserName,
            Email = userToRegister.Email,
            DateJoined = DateTime.Now
        };

        var createdUser = await _userManager.CreateAsync(newUser, userToRegister.Password);

        if (!createdUser.Succeeded)
        {
            return new AuthenticationResult
            {
                Errors = createdUser.Errors.Select(x => x.Description),
                ErrorCode = 400
            };
        }

        return await GenerateAuthResultAsync(newUser);
    }

    public async Task<AuthenticationResult> LoginAsync(LoginUserDto loginUserToLogin)
    {
        User user;
        if (AuthHelper.IsValidEmail(loginUserToLogin.UserNameOrEmail))
            user = await _userManager.FindByEmailAsync(loginUserToLogin.UserNameOrEmail);
        else
            user = await _userManager.FindByNameAsync(loginUserToLogin.UserNameOrEmail);
            
        if (user == null)
        {
            return new AuthenticationResult
            {
                Errors = new[] {"User does not exist"},
                ErrorCode = 401
            };
        }

        var validPassword = await _userManager.CheckPasswordAsync(user, loginUserToLogin.Password);

        if (!validPassword)
        {
            return new AuthenticationResult
            {
                Errors = new[] { "Incorrect Password" },
                ErrorCode = 401
            };
        }

        return await GenerateAuthResultAsync(user);
    }

    public async Task<AuthenticationResult> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
    {
        var validatedToken = GetPrincipalFromToken(refreshTokenDto.Token);
        if (validatedToken is null)
        {
            return new AuthenticationResult
            {
                Errors = new[] { "Invalid Token" },
                ErrorCode = 401
            };
        }
            
        // var expiryDateUnix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
        // var expiryDateUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        //     .AddSeconds(expiryDateUnix);
        //     
        // if (expiryDateUtc > DateTime.UtcNow)
        // {
        //     return new AuthenticationResult
        //     {
        //         Errors = new[] { "This token hasn't expired yet" },
        //         ErrorCode = 400
        //     };
        // }
            
        var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
        var storedRefreshToken = await _refreshTokenRepository.GetAsync(x => x.Id == refreshTokenDto.RefreshToken);
            
        if (storedRefreshToken is null)
        {
            return new AuthenticationResult
            {
                Errors = new[] { "This token does not exist" },
                ErrorCode = 401
            };
        }

        if (DateTime.UtcNow > storedRefreshToken.ExpiresAt)
        {
            return new AuthenticationResult
            {
                Errors = new[] { "This token has expired" },
                ErrorCode = 401
            };
        }
            
        if (storedRefreshToken.Invalidated)
        {
            return new AuthenticationResult
            {
                Errors = new[] { "This token has been invalidated" },
                ErrorCode = 401
            };
        }
           
        //Commenting this for now to solve frontend issue
        // if (storedRefreshToken.Used)
        // {
        //     return new AuthenticationResult
        //     {
        //         Errors = new[] { "This token has been used" },
        //         ErrorCode = 400
        //     };
        // }
            
        if (storedRefreshToken.JwtId != jti)
        {
            return new AuthenticationResult
            {
                Errors = new[] { "This token does not match this JWT" },
                ErrorCode = 400
            };
        } 

        storedRefreshToken.Used = true;
        await _refreshTokenRepository.UpdateAsync(storedRefreshToken);
            
        var user = await _userManager.FindByIdAsync(validatedToken.Claims.Single(x => x.Type == "id").Value);
        return await GenerateAuthResultAsync(user);
    }

    private ClaimsPrincipal? GetPrincipalFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            _tokenValidationParameters.ValidateLifetime = false;
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
            _tokenValidationParameters.ValidateLifetime = true;
            if (IsJwtWithValidSecurityAlgorithm(validatedToken)) return principal;
                
            _logger.LogWarning("Jwt has invalid security algorithm");
            return null;

        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Error while validating token");
            return null;
        }
    }
        
    private static bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
    {
        return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
               jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                   StringComparison.InvariantCultureIgnoreCase);
    }
        
    private async Task<AuthenticationResult> GenerateAuthResultAsync(User newUser)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            //All information about our user stored in jwt
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                new Claim("username", newUser.UserName),
                new Claim("firstName", newUser.FirstName),
                new Claim("lastName", newUser.LastName),
                new Claim("id", newUser.Id.ToString()),
            }),
            Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
            
        var refreshToken = new RefreshToken
        {
            JwtId = token.Id,
            JwtValue = tokenHandler.WriteToken(token),
            UserId = newUser.Id,
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = RefreshTokenUtilities.GetRefreshTokenExpiryDate()
        };
            
        await _refreshTokenRepository.CreateAsync(refreshToken);

        return new AuthenticationResult
        {
            Success = true,
            Token = tokenHandler.WriteToken(token),
            RefreshToken = refreshToken.Id,
            ValidFrom = token.ValidFrom.ToLocalTime(),
            ValidTo = token.ValidTo.ToLocalTime()
        };
    }
}