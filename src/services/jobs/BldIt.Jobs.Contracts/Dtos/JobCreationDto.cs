using BldIt.Jobs.Core.Enums;

namespace BldIt.Jobs.Contracts.Dtos
{
    public class JobCreationDto
    {
        //This is basically the job name, since they are unique
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public JobType JobType { get; set; }

        //public ICollection<BuildStep> BuildSteps { get; set; }
    }
}