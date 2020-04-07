using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Microsoft.Extensions.DependencyInjection;

namespace Blauhaus.DevicesServices.Platforms.iOS._Ioc
{
    public class IosServices : ServiceCollection
    {
        public IosServices()
        {
            this.AddSingleton<IRuntimePlatform>(RuntimePlatform.iOS);
        }
    }
}