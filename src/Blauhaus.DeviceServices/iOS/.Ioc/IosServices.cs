using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.iOS.Ioc
{
    public class IosServices : ServiceCollection
    {
        public IosServices()
        {
            this.AddSingleton<IRuntimePlatform>(RuntimePlatform.iOS);
            this.AddSingleton<IDeviceInfoService, IosDeviceInfoService>();
        }
    }
}