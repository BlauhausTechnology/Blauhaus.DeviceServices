using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Common.Application;
using Blauhaus.DeviceServices.Common.SecureStorage;
using Blauhaus.DeviceServices.Platforms.UWP;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.UWP._Ioc
{
    public class UwpServices : ServiceCollection
    {
        public UwpServices()
        {
            this.AddSingleton<IRuntimePlatform>(RuntimePlatform.UWP);
            this.AddSingleton<IDeviceInfoService, UwpDeviceInfoService>();
            
            this.AddTransient<IApplicationInfoService, ApplicationInfoService>();
            this.AddTransient<ISecureStorageService, SecureStorageService>();
        }
    }
}