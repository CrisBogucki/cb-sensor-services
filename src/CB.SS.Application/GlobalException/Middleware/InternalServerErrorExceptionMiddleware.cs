using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Auge.Api.SmartBuildingEnergyManagement.Src.Application.GlobalException.Middleware;

public class InternalServerErrorExceptionMiddleware
{
    private readonly ILogger<InternalServerErrorExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public InternalServerErrorExceptionMiddleware(RequestDelegate next,
        ILogger<InternalServerErrorExceptionMiddleware> logger)
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
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        //context.Response.StatusCode = 999;

        await context.Response.WriteAsync(
            new ErrorDetails(
                context.Response.StatusCode,
                "Oops something went wrong from env ...",
                new List<string>()).ToString());
    }
}