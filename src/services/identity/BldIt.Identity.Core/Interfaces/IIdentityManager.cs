using BldIt.Identity.Contracts.Dtos;
using BldIt.Identity.Contracts.Results;

namespace BldIt.Identity.Core.Interfaces;

public interface IIdentityManager
{
    Task<AuthenticationResult> RegisterAsync(RegisterUserDto userToRegister);
    Task<AuthenticationResult> LoginAsync(LoginUserDto userToLogin);
    Task<AuthenticationResult> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
}