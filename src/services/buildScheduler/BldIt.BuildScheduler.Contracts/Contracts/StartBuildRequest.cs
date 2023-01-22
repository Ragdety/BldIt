namespace BldIt.BuildScheduler.Contracts.Contracts;

public record StartBuildRequest(Guid BuildConfigId, int BuildNumber, CancellationToken StoppingToken);