using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.DeviceServices.Common.Application;
using Blauhaus.DeviceServices.Common.SecureStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.Android._Ioc
{
    public class AndroidServices : ServiceCollection
    {
        public AndroidServices()
        {
            this.AddSingleton<IRuntimePlatform>(RuntimePlatform.Android);
            this.AddSingleton<IDeviceInfoService, AndroidDeviceInfoService>();
            
            this.AddTransient<IApplicationInfoService, ApplicationInfoService>();
            this.AddTransient<ISecureStorageService, SecureStorageService>();
        }
    }
}