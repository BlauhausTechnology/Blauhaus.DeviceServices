using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Abstractions.Thread;
using Blauhaus.DeviceServices.Common.Application;
using Blauhaus.DeviceServices.Common.DeviceInfo;
using Blauhaus.DeviceServices.Common.SecureStorage;
using Blauhaus.DeviceServices.Common.Thread;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.Common._Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDeviceServices(this IServiceCollection services)
        {
            services.AddTransient<IApplicationInfoService, ApplicationInfoService>();
            services.AddTransient<ISecureStorageService, SecureStorageService>();
            services.AddTransient<IThreadService, ThreadService>();
            return services;
        }
    }
}