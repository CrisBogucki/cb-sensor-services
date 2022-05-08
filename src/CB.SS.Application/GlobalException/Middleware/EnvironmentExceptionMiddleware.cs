using CB.SensorService.Src.Domain.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CB.SensorService.Src.Application.GlobalException.Middleware;

public class EnvironmentExceptionMiddleware
{
    private readonly ILogger<EnvironmentExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public EnvironmentExceptionMiddleware(RequestDelegate next, ILogger<EnvironmentExceptionMiddleware> logger)
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
        catch (EnvironmentException ex)
        {
            _logger.LogError($"Oops something went wrong from enviroment: {ex.Message}");
            await HandleExceptionAsync(httpContext);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 997;

        await context.Response.WriteAsync(
            new ErrorDetails(
                context.Response.StatusCode,
                "Oops something went wrong from env ...",
                new List<string>()).ToString());
    }
}