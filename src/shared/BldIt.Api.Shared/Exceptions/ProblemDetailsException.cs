using Microsoft.AspNetCore.Mvc;

namespace BldIt.Api.Shared.Exceptions;

public class ProblemDetailsException : Exception
{
    public ProblemDetails ProblemDetails { get; set; }

    public override string Message
    {
        get
        {
            if (ProblemDetails.Title == null)
            {
                throw new ArgumentNullException(nameof(ProblemDetails.Title));
            }

            return ProblemDetails.Title;
        }
    }

    public ProblemDetailsException(ProblemDetails problemDetails) : base(null)
    {
        ProblemDetails = problemDetails;
    }
}