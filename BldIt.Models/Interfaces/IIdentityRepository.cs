using System.Threading.Tasks;
using BldIt.Models.Forms;
using BldIt.Models.Results;

namespace BldIt.Models.Interfaces
{
    public interface IIdentityRepository
    {
        Task<AuthenticationResult> RegisterAsync(UserRegistrationForm userToRegister);
        Task<AuthenticationResult> LoginAsync(UserLoginForm userToLogin);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}