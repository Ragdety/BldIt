using BldIt.Builds.Contracts.Enums;

namespace BldIt.Builds.Core.Dtos;

public class CreateBuildStepDto
{
    public string Command { get; set; }
    public BuildStepType Type { get; set; }
}