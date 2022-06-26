using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BldIt.Api.Services;
using BldIt.Models.Exceptions;
using BldIt.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BldIt.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModel = context.ModelState
                    .Where(x => x.Value != null && x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, 
                        kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage));

                var errors = new List<ErrorModel>();

                foreach (var (key, value) in errorsInModel)
                {
                    if (value == null) continue;
                    errors.AddRange(value.Select(subError => 
                        new ErrorModel {FieldName = key, Message = subError}));
                }

                //throw new DomainModelStateException("One or more model errors occurred", errors);
                var response = new ErrorResponse
                {
                    Message = "One or more model validation errors",
                    Errors = errors
                };

                context.Result = new UnprocessableEntityObjectResult(response);
                return;
            }
            
            await next();
        }
    }
}