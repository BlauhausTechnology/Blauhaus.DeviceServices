using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DeviceServices.Platforms.Android._Ioc
{
    public class AndroidServices : ServiceCollection
    {
        public AndroidServices()
        {
            this.AddSingleton<IRuntimePlatform>(RuntimePlatform.Android);
        }
    }
}