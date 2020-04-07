using System;
using System.Threading.Tasks;
using Blauhaus.Common.ValueObjects.DeviceType;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Xamarin.Essentials;
using DeviceType = Blauhaus.Common.ValueObjects.DeviceType.DeviceType;

namespace Blauhaus.DeviceServices.Core.DeviceInfo
{
    public partial class DeviceInfoService : IDeviceInfoService
    {

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
        public string AppDataFolder { get; }
    }
}