using Blauhaus.Common.Abstractions;
using Blauhaus.DeviceServices.Blazor.Server.Services;

namespace Blauhaus.DeviceServices.Blazor.Server.Ioc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorServerDeviceServices(this IServiceCollection services)
    {
        services.AddScoped<IKeyValueStore, BlazorServerKeyValueStore>();
        return services;
    }
}