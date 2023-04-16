using BldIt.Builds.Contracts.Keys;

namespace BldIt.Builds.Contracts.Contracts;

public record BuildStepDeleted(Guid JobId, BuildStepKey BuildStepId);