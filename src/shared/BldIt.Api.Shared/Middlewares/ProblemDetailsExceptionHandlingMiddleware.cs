using BldIt.Api.Shared.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BldIt.Api.Shared.Middlewares
{
    public class ProblemDetailsExceptionHandlingMiddleware : IMiddleware
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ProblemDetailsExceptionHandlingMiddleware> _logger;

        public ProblemDetailsExceptionHandlingMiddleware(
            IWebHostEnvironment env,
            ILogger<ProblemDetailsExceptionHandlingMiddleware> logger)
        {
            _env = env;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ProblemDetailsException e)
            {
                var problemDetails = e.ProblemDetails;
                context.Response.StatusCode = (int) problemDetails.Status!;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}