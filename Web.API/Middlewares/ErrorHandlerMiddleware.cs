using Application.Exceptions;
using Application.Wrappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                string message = string.Empty;
                message = $"{error?.Message}{error?.InnerException}";
//#if DEBUG
//                message = $"{error?.Message} {error?.InnerException}\n{error.StackTrace}";
//#endif
                var responseModel = new Response<string>() 
                { 
                    Successed = false, 
                    Message = message
                };

                switch (error)
                {
                    case ApiException _:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case CustomValidationException e:
                        // invalid data / не прошел вадацию
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        responseModel.ValidationErrors = e.Failures;
                        responseModel.Errors = e.Failures;
                        break;
                    case KeyNotFoundException _:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case NotFoundException _:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case UnauthorizedException _:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
                var result = JsonConvert.SerializeObject(responseModel,
                    new JsonSerializerSettings { Formatting = Formatting.Indented, ContractResolver = contractResolver });

                await response.WriteAsync(result);
            }
        }
    }
}
