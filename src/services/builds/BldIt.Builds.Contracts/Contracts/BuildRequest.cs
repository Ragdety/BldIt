namespace BldIt.Builds.Contracts.Contracts;

public record BuildRequest(Guid BuildId, Guid BuildConfigId, int BuildNumber);