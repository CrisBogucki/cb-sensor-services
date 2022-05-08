using Auge.Api.SmartBuildingEnergyManagement.Src.Application.GlobalException;
using Auge.Api.SmartBuildingEnergyManagement.Src.Application.Pipeline;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Auge.Api.SmartBuildingEnergyManagement.Src.Application;

public class Context
{
}

public static class ServiceContainer
{
    public static void AddConfigureServices(this IServiceCollection services)
    {
        services.AddControllers()
            .AddFluentValidation(s => { s.RegisterValidatorsFromAssemblyContaining<Context>(); });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
    }

    public static void AddConfigureExceptionServices(this IApplicationBuilder builder)
    {
        builder.AddConfigureExceptionGlobalHandler();
    }
}