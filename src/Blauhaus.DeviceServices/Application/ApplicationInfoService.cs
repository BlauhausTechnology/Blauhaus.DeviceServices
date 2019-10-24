using Blauhaus.DeviceServices.Abstractions.Application;
using Xamarin.Essentials;

namespace Blauhaus.DeviceServices.Application
{
    public class ApplicationInfoService : IApplicationInfoService
    {
        private Platform _platform;

        public string CurrentVersion => VersionTracking.CurrentVersion;

        public Platform Platform
        {
            get
            {
                if (_platform == Platform.Unknown)
                {
                    if (Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.Android)
                    {
                        _platform = Platform.Android;
                    }
                    else if (Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.iOS)
                    {
                        _platform = Platform.iOS;
                    }
                    else if (Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.UWP)
                    {
                        _platform = Platform.UWP;
                    }
                }
                return _platform;
            }
        }
    }
}