using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BldIt.Data.Settings;
using BldIt.Models.DataModels;
using BldIt.Models.Forms;
using BldIt.Models.Helpers;
using BldIt.Models.Interfaces;
using BldIt.Models.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BldIt.Data.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;

        public IdentityRepository(
            UserManager<User> userManager, 
            JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }
        
        public async Task<AuthenticationResult> RegisterAsync(UserRegistrationForm userToRegister)
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

        public async Task<AuthenticationResult> LoginAsync(UserLoginForm userToLogin)
        {
            User user;
            if (AuthHelper.IsValidEmail(userToLogin.UserNameOrEmail))
                user = await _userManager.FindByEmailAsync(userToLogin.UserNameOrEmail);
            else
                user = await _userManager.FindByNameAsync(userToLogin.UserNameOrEmail);
            
            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] {"User does not exist"}
                };
            }

            var validPassword = await _userManager.CheckPasswordAsync(user, userToLogin.Password);

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