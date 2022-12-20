using BldIt.BuildScheduler.Contracts.Enums;

namespace BldIt.BuildScheduler.Contracts.Contracts;

public record BuildStatusUpdated(Guid BuildConfigId, int BuildNumber, BuildStatus BuildStatus);