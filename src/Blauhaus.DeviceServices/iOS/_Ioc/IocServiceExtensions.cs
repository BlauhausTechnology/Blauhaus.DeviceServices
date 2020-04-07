using Blauhaus.Ioc.Abstractions;

namespace Blauhaus.DeviceServices.iOS._Ioc
{
    public static class IocServiceExtensions
    {
        public static IIocService AddDeviceServices(this IIocService iocService)
        {
            iocService.RegisterInstance<IRuntimePlatform>(RuntimePlatform.iOS);
            iocService.RegisterImplementation<IDeviceInfoService, IosDeviceInfoService>(IocLifetime.Singleton);
            return iocService;
        }
    }
}