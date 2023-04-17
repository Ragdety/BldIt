using BldIt.Builds.Contracts.Enums;

namespace BldIt.Builds.Core.Dtos;

public class CreateBuildConfigDto
{
    public BuildTrigger BuildTrigger { get; set; }
    
    public ICollection<CreateBuildStepDto> BuildSteps 
        { get; set; } = new List<CreateBuildStepDto>();
}