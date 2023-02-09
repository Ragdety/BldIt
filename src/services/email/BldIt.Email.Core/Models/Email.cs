namespace BldIt.Email.Core;
using BldIt.Api.Shared.Interfaces;

public class Email : IEntity<Guid>
{
    public Guid Id { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; init; }
    
    public string SendFrom { get; set; }
    public string SendTo { get; set; }
    public string Message { get; set; }
}