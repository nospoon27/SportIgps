using Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Filters
{
    public class OverridingResultFilter : IAlwaysRunResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is StatusCodeResult statusCodeResult 
                && statusCodeResult.StatusCode == StatusCodes.Status415UnsupportedMediaType)
            {
                var response = new Response<string>("Не поддерживаемый медиа-формат");
                response.Successed = false;

                context.Result = new ObjectResult(response)
                {
                    StatusCode = 415,
                    Value = response,
                };
            }
        }
    }
}
