using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Common.Application;
using Blauhaus.DeviceServices.Common.DeviceInfo;
using Blauhaus.DeviceServices.Common.SecureStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.Common._Ioc
{
    public static class IocServiceExtensions
    {
        public static IIocService AddDeviceServices(this IIocService iocService)
        {
            iocService.RegisterImplementation<IApplicationInfoService, ApplicationInfoService>();
            iocService.RegisterImplementation<ISecureStorageService, SecureStorageService>();
            return iocService;
        }
    }
}