using BldIt.Builds.Contracts.Enums;

namespace BldIt.BuildWorker.Contracts.Contracts;

public record BuildStatusUpdated(Guid BuildId, Guid BuildConfigId, int BuildNumber, BuildStatus BuildStatus); 