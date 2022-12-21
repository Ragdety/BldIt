namespace BldIt.Jobs.Contracts.Contracts;

public record JobUpdated(
    Guid JobId,
    string JobName
    );