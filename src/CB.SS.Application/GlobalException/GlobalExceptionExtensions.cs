using CB.SensorService.Src.Application.GlobalException.Middleware;
using Microsoft.AspNetCore.Builder;

namespace CB.SensorService.Src.Application.GlobalException;

public static class ExceptionExtensions
{
    public static void AddConfigureExceptionGlobalHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<InternalServerErrorExceptionMiddleware>();
        app.UseMiddleware<EnvironmentExceptionMiddleware>();
        app.UseMiddleware<ValidationExceptionMiddleware>();
    }
}