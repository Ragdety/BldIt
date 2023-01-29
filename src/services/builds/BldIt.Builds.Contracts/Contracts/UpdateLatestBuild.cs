namespace BldIt.Builds.Contracts.Contracts;

public record UpdateLatestBuild(Guid JobId, int OldBuildNumber);