namespace BldIt.Builds.Contracts.Contracts;

public record BuildStepDeleted(Guid JobId, Guid BuildConfigId, int BuildStepNumber);