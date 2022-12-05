namespace BldIt.Builds.Contracts.Contracts;

public record BuildCreated(Guid Id, string Status, int BuildNumber, Guid jobId);