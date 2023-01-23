namespace BldIt.BuildScheduler.Contracts.Contracts;

public record StartBuildRequest(Guid BuildId, Guid BuildConfigId, int BuildNumber);