using System;
using System.Threading.Tasks;
using Blauhaus.Common.ValueObjects.DeviceType;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Xamarin.Essentials;
using DeviceType = Blauhaus.Common.ValueObjects.DeviceType.DeviceType;

namespace Blauhaus.DeviceServices.DeviceInfo
{
    public class DeviceInfoService : IDeviceInfoService
    {
        private string? _deviceId;

        public DeviceInfoService()
        {
            AppDataFolder = FileSystem.AppDataDirectory;

            if (Xamarin.Essentials.DeviceInfo.Idiom == DeviceIdiom.Phone)
                Type = DeviceType.Phone;
            else if (Xamarin.Essentials.DeviceInfo.Idiom == DeviceIdiom.Tablet)
                Type = DeviceType.Tablet;
            else if (Xamarin.Essentials.DeviceInfo.Idiom == DeviceIdiom.Desktop)
                Type = DeviceType.PC;
            else if (Xamarin.Essentials.DeviceInfo.Idiom == DeviceIdiom.TV)
                Type = DeviceType.TV;
            else if (Xamarin.Essentials.DeviceInfo.Idiom == DeviceIdiom.Watch)
                Type = DeviceType.Watch;
            else
            {
                Type = DeviceType.Unknown;
            }

            Model = Xamarin.Essentials.DeviceInfo.Model;
            Manufacturer = Xamarin.Essentials.DeviceInfo.Manufacturer;
            OperatingSystemVersion = Xamarin.Essentials.DeviceInfo.VersionString;

            if (Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.Android)
            {
                Platform = RuntimePlatform.Android;
            }
            else if (Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.iOS)
            {
                Platform = RuntimePlatform.iOS;
            }
            else if (Xamarin.Essentials.DeviceInfo.Platform == DevicePlatform.UWP)
            {
                Platform = RuntimePlatform.UWP;
            }
            else
            {
                Platform = RuntimePlatform.Unknown;
            }
        }
        
        public IDeviceType Type { get; }
        public IRuntimePlatform Platform { get; }
        public string OperatingSystemVersion { get; }
        public string Manufacturer { get; }
        public string Model { get; }
        public string DeviceUniqueIdentifier
        {
            get
            {
                if (_deviceId == null)
                {
                    _deviceId = Task.Run(() => Xamarin.Essentials.SecureStorage.GetAsync("DeviceUniqueIdentifier")).GetAwaiter().GetResult();
                    if (string.IsNullOrEmpty(_deviceId))
                    {
                        _deviceId = Guid.NewGuid().ToString();
                        Xamarin.Essentials.SecureStorage.SetAsync("DeviceUniqueIdentifier", DeviceUniqueIdentifier);
                    }
                }
                return _deviceId;
            }
        }
        public string AppDataFolder { get; }
    }
}