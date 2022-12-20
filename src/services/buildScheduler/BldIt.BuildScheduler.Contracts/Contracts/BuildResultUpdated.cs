using BldIt.BuildScheduler.Contracts.Enums;

namespace BldIt.BuildScheduler.Contracts.Contracts;

public record BuildResultUpdated(Guid BuildConfigId, int BuildNumber, BuildResult BuildResult);