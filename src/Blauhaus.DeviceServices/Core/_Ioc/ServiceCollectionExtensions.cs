using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Core.Application;
using Blauhaus.DeviceServices.Core.DeviceInfo;
using Blauhaus.DeviceServices.Core.SecureStorage;
using Blauhaus.Ioc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.Core._Ioc
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