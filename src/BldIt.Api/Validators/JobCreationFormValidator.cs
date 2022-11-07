using BldIt.Models.Forms;
using FluentValidation;

namespace BldIt.Api.Validators
{
    public class JobCreationFormValidator : AbstractValidator<JobCreationForm>
    {
        public JobCreationFormValidator()
        {
            RuleFor(x => x.JobName)
                .NotEmpty()
                .NotNull()
                //Match strings with no special characters
                .Matches("^[a-zA-Z0-9 ]*$");
        }
    }
}