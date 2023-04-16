namespace BldIt.Jobs.Contracts.Contracts;

public record JobConfigCreated(Guid JobConfigId, Guid JobId, string JobWorkspacePath);