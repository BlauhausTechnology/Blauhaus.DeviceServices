using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Blauhaus.DeviceServices.Abstractions.Permissions;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Abstractions.Share;
using Blauhaus.DeviceServices.Abstractions.Thread;
using Blauhaus.DeviceServices.Common.Application;
using Blauhaus.DeviceServices.Common.Connectivity;
using Blauhaus.DeviceServices.Common.Permissions;
using Blauhaus.DeviceServices.Common.SecureStorage;
using Blauhaus.DeviceServices.Common.Share;
using Blauhaus.DeviceServices.Common.Thread;
using Blauhaus.Ioc.Abstractions;

namespace Blauhaus.DeviceServices.Common.Ioc
{
    public static class IocServiceExtensions
    {
        public static IIocService AddDeviceServices(this IIocService iocService)
        {
            iocService.RegisterImplementation<IApplicationInfoService, ApplicationInfoService>(IocLifetime.Singleton);
            iocService.RegisterImplementation<ISecureStorageService, SecureStorageService>(IocLifetime.Singleton);
            iocService.RegisterImplementation<IThreadService, ThreadService>(IocLifetime.Singleton);
            iocService.RegisterImplementation<IConnectivityService, ConnectivityService>(IocLifetime.Singleton);
            iocService.RegisterImplementation<IDevicePermissionsService, DevicePermissionsService>(IocLifetime.Singleton);
            iocService.RegisterImplementation<IShareService, ShareService>(IocLifetime.Singleton);
            return iocService;
        }
    }
}