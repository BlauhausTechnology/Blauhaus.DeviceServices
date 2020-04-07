using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.Platforms.UWP._Ioc
{
    public class UwpServices : ServiceCollection
    {
        public UwpServices()
        {
            this.AddSingleton<IRuntimePlatform>(RuntimePlatform.UWP);
        }
    }
}