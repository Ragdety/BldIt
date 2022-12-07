namespace BldIt.Jobs.Contracts.Contracts;

public record JobCreated(
    Guid Id,
    string JobName,
    Guid ProjectId);