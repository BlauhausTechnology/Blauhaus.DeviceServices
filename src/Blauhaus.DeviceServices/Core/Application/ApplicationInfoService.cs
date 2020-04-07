using Blauhaus.DeviceServices.Abstractions.Application;
using Xamarin.Essentials;

namespace Blauhaus.DeviceServices.Core.Application
{
    public class ApplicationInfoService : IApplicationInfoService
    {

        public string CurrentVersion => VersionTracking.CurrentVersion;

      
    }
}