using Blauhaus.Common.Abstractions;
using Blauhaus.DeviceServices.Blazor.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.Blazor.Ioc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorDeviceServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<IKeyValueStore, BlazorLocalStorageService>();
    }
}