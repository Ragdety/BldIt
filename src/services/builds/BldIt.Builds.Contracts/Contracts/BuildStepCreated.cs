using BldIt.Builds.Contracts.Enums;
using BldIt.Builds.Contracts.Keys;

namespace BldIt.Builds.Contracts.Contracts;

public record BuildStepCreated(
    BuildStepKey BuildStepKey, 
    string Command,
    BuildStepType BuildStepType);