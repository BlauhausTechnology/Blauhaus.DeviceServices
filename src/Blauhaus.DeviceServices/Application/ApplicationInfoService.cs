using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.Application;
using Xamarin.Essentials;

namespace Blauhaus.DeviceServices.Application
{
    public class ApplicationInfoService : IApplicationInfoService
    {

        public string CurrentVersion => VersionTracking.CurrentVersion;

      
    }
}