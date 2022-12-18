using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Core.Enums;

namespace BldIt.Jobs.Core.Models;

public class FreestyleStep : IEntity<int>
{
    public int Id { get; set; }
    public bool Deleted { get; set; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    
    public string Command { get; set; }
    public StepType Type { get; set; }
    
    public Guid JobConfigId { get; set; }
}