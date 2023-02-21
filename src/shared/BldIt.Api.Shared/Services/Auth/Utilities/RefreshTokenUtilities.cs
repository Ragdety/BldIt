namespace BldIt.Api.Shared.Services.Auth.Utilities;

public static class RefreshTokenUtilities
{
    public static DateTime GetRefreshTokenExpiryDate() => DateTime.UtcNow.AddDays(7);
    
    public const string CookieName = "refreshToken";
}