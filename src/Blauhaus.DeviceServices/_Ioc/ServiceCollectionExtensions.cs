using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Application;
using Blauhaus.DeviceServices.DeviceInfo;
using Blauhaus.DeviceServices.SecureStorage;
using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices._Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDeviceServices(this IServiceCollection services)
        {
            services.AddTransient<ISecureStorageService, SecureStorageService>();
            services.AddSingleton<IDeviceInfoService, DeviceInfoService>();
            services.AddTransient<IApplicationInfoService, ApplicationInfoService>();
            return services;
        }
    }
}