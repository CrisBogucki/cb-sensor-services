using Auge.Api.SmartBuildingEnergyManagement.Src.Domain.Services;
using Auge.Api.SmartBuildingEnergyManagement.Src.Infrastrucure.Rest.Service;

namespace Auge.Api.SmartBuildingEnergyManagement.Src.Host;

public static class ServiceContainer
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IRestService, RestService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddScoped<IStructureService, GraphItemService>();
    }
}