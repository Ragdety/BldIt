using BldIt.Api.Shared.Interfaces;

namespace BldIt.Identity.Core.Models;

public class RefreshToken : IEntity<Guid>
{
    //Id is the token
    public Guid Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public string JwtId { get; set; }
    public string JwtValue { get; set; }
    public DateTime ExpiresAt { get; set; }
    
    public bool Used { get; set; }
    public bool Invalidated { get; set; }
    public Guid UserId { get; set; }
}