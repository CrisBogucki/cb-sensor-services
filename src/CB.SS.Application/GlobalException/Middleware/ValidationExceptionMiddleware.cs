using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CB.SensorService.Src.Application.GlobalException.Middleware;

public class ValidationExceptionMiddleware
{
    private readonly ILogger<ValidationExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ValidationExceptionMiddleware(RequestDelegate next, ILogger<ValidationExceptionMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
                .Select(x => new ValidateDetails(x.PropertyName, x.ErrorMessage)).Distinct();

            await HandleExceptionAsync(httpContext, errors);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, IEnumerable<ValidateDetails> validateDetails)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 998;

        await context.Response.WriteAsync(
            new ErrorDetails(
                    context.Response.StatusCode,
                    "Oops something went wrong from valid ...",
                    validateDetails.Select(x => x.Message))
                .ToString());
    }
}