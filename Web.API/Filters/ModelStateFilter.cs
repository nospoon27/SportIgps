using Application.Exceptions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Filters
{
    public class ModelStateFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var errors = context.ModelState.Select(e => new ValidationFailure(e.Key, string.Join(";", e.Value.Errors.Select(x => x.ErrorMessage)))).ToList();
            if (!context.ModelState.IsValid)
            {
                throw new CustomValidationException(new List<ValidationFailure>(errors));
            }

            await next();
        }
    }
}
