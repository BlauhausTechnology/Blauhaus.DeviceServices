using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Common.Application;
using Blauhaus.DeviceServices.Common.SecureStorage;
using Blauhaus.DeviceServices.Platforms.iOS;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.iOS._Ioc
{
    public class IosServices : ServiceCollection
    {
        public IosServices()
        {
            this.AddSingleton<IRuntimePlatform>(RuntimePlatform.iOS);
            this.AddSingleton<IDeviceInfoService, IosDeviceInfoService>();
            this.AddTransient<IApplicationInfoService, ApplicationInfoService>();
            this.AddTransient<ISecureStorageService, SecureStorageService>();
        }
    }
}