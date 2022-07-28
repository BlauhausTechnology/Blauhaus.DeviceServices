using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.Permissions;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Abstractions.Thread;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Blauhaus.DeviceServices.Maui.Ioc;

public static class ServiceCollectionExtensions
{


    public static IServiceCollection AddMauiDeviceServices(this IServiceCollection services)
    {
        services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
        services.AddSingleton<IConnectivityService, ConnectivityService>();
        services.AddSingleton<IDevicePermissionsService, DevicePermissionsService>();
        services.AddSingleton<ISecureStorageService, SecureStorageService>();
        services.AddSingleton<IThreadService, ThreadService>();
        

#if IOS
        services.TryAddSingleton<IDeviceInfoService, IosDeviceInfoService>();
        services.AddSingleton<IRuntimePlatform>(RuntimePlatform.iOS);

#elif ANDROID
        services.TryAddSingleton<IDeviceInfoService, AndroidDeviceInfoService>();
        services.AddSingleton<IRuntimePlatform>(RuntimePlatform.Android);
        
#elif WINDOWS10_0_19041_0
        services.TryAddSingleton<IDeviceInfoService, WindowsDeviceInfoService>();
        services.AddSingleton<IRuntimePlatform>(RuntimePlatform.Windows);
     
#elif __MACCATALYST__
        services.TryAddSingleton<IDeviceInfoService, MacCatalystDeviceInfoService>();
        services.AddSingleton<IRuntimePlatform>(RuntimePlatform.Mac);

#else
        services.AddSingleton<IDeviceInfoService, DeviceInfoService>();
        services.AddSingleton<IRuntimePlatform>(RuntimePlatform.Unknown);

#endif
        
        return services;
    }
}