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
using Blauhaus.Ioc.Abstractions;

namespace Blauhaus.DeviceServices.Common._Ioc
{
    public static class IocServiceExtensions
    {
        public static IIocService AddDeviceServices(this IIocService iocService)
        {
            iocService.RegisterImplementation<IApplicationInfoService, ApplicationInfoService>();
            iocService.RegisterImplementation<ISecureStorageService, SecureStorageService>();
            iocService.RegisterImplementation<IThreadService, ThreadService>();
            iocService.RegisterImplementation<IConnectivityService, ConnectivityService>();
            iocService.RegisterImplementation<IDevicePermissionsService, DevicePermissionsService>();
            return iocService;
        }
    }
}