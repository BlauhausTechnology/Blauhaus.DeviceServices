﻿using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Common.Application;
using Blauhaus.DeviceServices.Common.SecureStorage;
using Blauhaus.Ioc.Abstractions;

namespace Blauhaus.DeviceServices.UWP.Ioc
{
    public static class IocServiceExtensions
    {
        public static IIocService AddDeviceServices(this IIocService iocService)
        {
            iocService.RegisterInstance<IRuntimePlatform>(RuntimePlatform.UWP);
            iocService.RegisterImplementation<IDeviceInfoService, UwpDeviceInfoService>(IocLifetime.Singleton);
            iocService.RegisterImplementation<IApplicationInfoService, ApplicationInfoService>();
            iocService.RegisterImplementation<ISecureStorageService, SecureStorageService>();
            return iocService;
        }
    }
}