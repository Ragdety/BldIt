using System.IO;
using BldIt.Api.Form;
using FluentValidation;

namespace BldIt.Api.Validators
{
    public class JobCreationFormValidator : AbstractValidator<JobCreationForm>
    {
        public JobCreationFormValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                //Match strings with no special characters
                .Matches("^[a-zA-Z0-9 ]*$");

            RuleFor(x => x.JobWorkspacePath)
                .Must(JobWorkspacePathExists)
                .WithMessage("Path to custom workspace does not exist");
        }

        private static bool JobWorkspacePathExists(string dirPath) => Directory.Exists(dirPath);
    }
}