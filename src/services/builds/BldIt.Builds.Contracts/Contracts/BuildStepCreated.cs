using BldIt.Builds.Contracts.Enums;

namespace BldIt.Builds.Contracts.Contracts;

public record BuildStepCreated(
    Guid BuildConfigId, 
    int BuildStepNumber, 
    string Command,
    BuildStepType BuildStepType);