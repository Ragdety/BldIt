using BldIt.Builds.Contracts.Enums;

namespace BldIt.BuildScheduler.Contracts.Contracts;

public record BuildStatusUpdated(Guid BuildConfigId, int BuildNumber, BuildStatus BuildStatus);