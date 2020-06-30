using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voter.Application.Exceptions;

namespace Voter.Api.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                switch(ex)
                {
                    case UnauthorizedUseCaseException _:
                        statusCode = StatusCodes.Status403Forbidden;
                        response = new
                        {
                            message = "You are not allowed to execute this command."
                        };
                        break;
                    case EntityNotFoundException _:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            message = "The item you were looking for was not found."
                        };
                        break;
                    case PersonIsAdminException _:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = "Person which is an administrator can not be deleted."
                        };
                        break;
                    case NotAllowedToViewOrEditException _:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = "You are only allowed to view and edit data in your country."
                        };
                        break;
                    case ValidationException validationException:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = "Validation Exception Errors.",
                            errors = validationException.Errors.Select(x => new
                            {
                                x.PropertyName,
                                x.ErrorMessage
                            })
                        };
                        break;
                }

                httpContext.Response.StatusCode = statusCode;

                if(response != null)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }

                await Task.FromResult(httpContext.Response);
            }
        }
    }
}
