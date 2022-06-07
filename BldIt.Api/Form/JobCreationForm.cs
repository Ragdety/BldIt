using BldIt.Models.Enums;

namespace BldIt.Api.Form
{
    public class JobCreationForm
    {
        //This is basically the job name, since they are unique
        public string Id { get; set; }
        public string JobDescription { get; set; }
        public JobType JobType { get; set; }
        public string JobWorkspacePath { get; set; }

        //public ICollection<BuildStep> BuildSteps { get; set; }
    }
}