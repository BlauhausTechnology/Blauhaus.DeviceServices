using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Common.Application;
using Blauhaus.DeviceServices.Common.DeviceInfo;
using Blauhaus.DeviceServices.Common.SecureStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.Common._Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDeviceServices(this IServiceCollection services)
        {
            services.AddSingleton<IDeviceInfoService, DeviceInfoService>();
            services.AddTransient<IApplicationInfoService, ApplicationInfoService>();
            services.AddTransient<ISecureStorageService, SecureStorageService>();
            return services;
        }
    }
}