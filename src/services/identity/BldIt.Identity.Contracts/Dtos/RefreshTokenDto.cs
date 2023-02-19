namespace BldIt.Identity.Contracts.Dtos;

public class RefreshTokenDto
{
    public string Token { get; set; }
    public Guid RefreshToken { get; set; }
}