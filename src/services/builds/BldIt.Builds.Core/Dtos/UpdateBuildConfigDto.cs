namespace BldIt.Builds.Core.Dtos;

public class UpdateBuildConfigDto
{
    public ICollection<CreateBuildStepDto> BuildSteps 
    { get; set; } = new List<CreateBuildStepDto>();
}