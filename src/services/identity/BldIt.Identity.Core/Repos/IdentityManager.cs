using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BldIt.Identity.Contracts.Dtos;
using BldIt.Identity.Contracts.Results;
using BldIt.Identity.Core.Helpers;
using BldIt.Identity.Core.Interfaces;
using BldIt.Identity.Core.Models;
using BldIt.Identity.Core.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BldIt.Identity.Core.Repos
{
    /// <summary>
    /// Manages authentication for a specific user.
    /// This is NOT a generic repo since it only handles registration and authentication.
    /// </summary>
    public class IdentityManager : IIdentityManager
    {
        //We can directly use UserManager since we injected it
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;

        public IdentityManager(
            UserManager<User> userManager, 
            JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }
        
        public async Task<AuthenticationResult> RegisterAsync(RegisterUserDto userToRegister)
        {
            var existingUser = await _userManager.FindByEmailAsync(userToRegister.Email);
            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] {"User with this email address already exists"}
                };
            }
            
            existingUser = await _userManager.FindByNameAsync(userToRegister.UserName);
            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] {"User with this username already exists"}
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
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            return GenerateAuthResult(newUser);
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
                    Errors = new[] {"User does not exist"}
                };
            }

            var validPassword = await _userManager.CheckPasswordAsync(user, loginUserToLogin.Password);

            if (!validPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Incorrect Password" }
                };
            }

            return GenerateAuthResult(user);
        }

        //TODO: implement later
        public Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        {
            throw new NotImplementedException();
        }
        
        private AuthenticationResult GenerateAuthResult(User newUser)
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
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                ValidFrom = token.ValidFrom.ToLocalTime(),
                ValidTo = token.ValidTo.ToLocalTime()
            };
        }
    }
}