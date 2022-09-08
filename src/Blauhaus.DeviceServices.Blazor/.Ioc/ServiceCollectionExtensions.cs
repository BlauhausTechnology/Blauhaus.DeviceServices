using Blauhaus.Common.Abstractions;
using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.Thread;
using Blauhaus.DeviceServices.Blazor.Services;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.Blazor.Ioc;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorDeviceServices(this IServiceCollection services)
    {
        return services
            .AddBlazoredLocalStorageAsSingleton()
            .AddSingleton<IKeyValueStore, BlazorLocalStorageService>()
            .AddSingleton<IApplicationInfoService, BlazorApplicationInfoService>()
            .AddSingleton<IConnectivityService, BlazorConnectivityService>()
            .AddSingleton<IThreadService, BlazorThreadService>()
            .AddSingleton<IDeviceInfoService, BlazorDeviceInfoService>();
    }
}