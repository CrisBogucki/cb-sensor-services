using Auge.Api.SmartBuildingEnergyManagement.Src.Domain.Utils;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Auge.Api.SmartBuildingEnergyManagement.Src.Host.Configuration;

public static class ServiceConfiguration
{
    public static void AddCfgServices(this IServiceCollection services)
    {
        services.AddCfgCors();
        services.AddCfgSwaggerInfo();
        services.AddConfigureRoute();
    }

    private static void AddCfgCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                    .WithOrigins(
                        "https://smartbuildingenergymanagement.aug-e.io/api/*",
                        "https://smartbuildingenergymanagement.aug-e.io/api/",
                        "https://smartbuildingenergymanagement.aug-e.io/api",
                        "https://smartbuildingenergymanagement.aug-e.io/*",
                        "https://smartbuildingenergymanagement.aug-e.io/",
                        "https://smartbuildingenergymanagement.aug-e.io",
                        "https://localhost:4200",
                        "http://localhost:4200",
                        "http://localhost:63342",
                        "http://localhost:80",
                        "http://localhost:443",
                        "http://localhost",
                        "*",
                        "*"
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );
        });
    }

    private static void AddCfgSwaggerInfo(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AUG-E Smart Building Energy Management API",
                Version = "v1",
                Description = "Interface for Smart Building Energy Management product"
            });
        });
    }

    private static void AddConfigureRoute(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
        });
    }

    public static ConfigureHostBuilder AddConfigureSeqMonitoring(this ConfigureHostBuilder host)
    {
        var seqServerUrl = EnvUtils.GetVal("SEQ_SERVER_URL");
        host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .WriteTo.Seq(seqServerUrl));
        return host;
    }
}