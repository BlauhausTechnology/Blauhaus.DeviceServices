using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Blauhaus.DeviceServices.Abstractions.Permissions;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Abstractions.Thread;
using Blauhaus.DeviceServices.Common.Application;
using Blauhaus.DeviceServices.Common.Connectivity;
using Blauhaus.DeviceServices.Common.Permissions;
using Blauhaus.DeviceServices.Common.SecureStorage;
using Blauhaus.DeviceServices.Common.Thread;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.Common.Ioc
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddDeviceServices(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
            services.AddSingleton<ISecureStorageService, SecureStorageService>();
            services.AddSingleton<IThreadService, ThreadService>();
            services.AddSingleton<IConnectivityService, ConnectivityService>();
            services.AddSingleton<IDevicePermissionsService, DevicePermissionsService>();
            return services;
        }
    }
}