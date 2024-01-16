using Fandul.Services.DepthChartProcessor.Application.Exceptions;
using Fandul.Services.DepthChartProcessor.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Fandul.Services.DepthChartProcessor.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var httpCode = HttpStatusCode.InternalServerError;
                var internalServerErrorMessage = "Internal Service Error";
                var errorResponse = new ErrorModel() { Description = internalServerErrorMessage };

                if (e is ValidationException validationEx)
                {
                    var errorModels = validationEx.Errors.Select(x => new ValidationErrorModel()
                    {
                        ErrorMessage = x.ErrorMessage,
                        AttemptedValue = x.AttemptedValue,
                        PropertyName = x.PropertyName
                    });

                    errorResponse.Description = "Validation error in th erequest payload";
                    errorResponse.ValidationErrors = errorModels;

                    httpCode = HttpStatusCode.BadRequest;
                }
                if (e is FandulExceptionBase exceptionBase)
                {
                    errorResponse.Description = exceptionBase.Description;

                    httpCode = exceptionBase.StatusCode;
                }

                context.Response.StatusCode = (int)httpCode;
                await context.Response.WriteAsJsonAsync(errorResponse);
            }

        }
    }
}
