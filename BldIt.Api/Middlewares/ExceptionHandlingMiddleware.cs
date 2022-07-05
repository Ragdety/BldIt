using System;
using System.Net;
using System.Threading.Tasks;
using BldIt.Api.Services;
using BldIt.Models.Exceptions;
using BldIt.Models.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BldIt.Api.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            IWebHostEnvironment env,
            ILogger<ExceptionHandlingMiddleware> logger)
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
            catch (DomainValidationException e)
            {
                var response = new FailResponse
                {
                    Message = e.Message,
                    Detail = e.Detail
                };
                context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (DomainUnauthorizedException e)
            {
                var response = new UnauthorizedResponse
                {
                    Message = e.Message
                };
                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (DomainNotFoundException e)
            {
                var response = new NotFoundResponse
                {
                    Message = e.Message
                };
                context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception e)
            {
                //TODO: Generate trace id later
                string errorMessage = "An error occurred...";
                var detail = "Internal exception occured";
                
                if (_env.IsDevelopment())
                {
                    errorMessage = e.Message;
                    detail = e.StackTrace;
                }
                
                _logger.LogError(e.StackTrace);

                var response = new FailResponse
                {
                    Message = errorMessage,
                    Detail = detail
                };
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}