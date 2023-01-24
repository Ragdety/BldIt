using BldIt.Builds.Contracts.Enums;

namespace BldIt.BuildWorker.Contracts.Contracts;

public record BuildResultUpdated(Guid BuildId, Guid BuildConfigId, int BuildNumber, BuildResult BuildResult);