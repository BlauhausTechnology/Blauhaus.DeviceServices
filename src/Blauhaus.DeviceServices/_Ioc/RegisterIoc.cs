using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Application;
using Blauhaus.DeviceServices.DeviceInfo;
using Blauhaus.DeviceServices.SecureStorage;
using Blauhaus.Ioc.Abstractions;

namespace Blauhaus.DeviceServices._Ioc
{
    public static class RegisterIoc
    {
        public static IIocService RegisterBlauhausDeviceServices(this IIocService iocService)
        {
            iocService.RegisterImplementation<ISecureStorageService, SecureStorageService>(IocLifetime.Singleton);
            iocService.RegisterImplementation<IDeviceInfoService, DeviceInfoService>(IocLifetime.Singleton);
            iocService.RegisterImplementation<IApplicationInfoService, ApplicationInfoService>(IocLifetime.Singleton);

            return iocService;
        }
    }
}