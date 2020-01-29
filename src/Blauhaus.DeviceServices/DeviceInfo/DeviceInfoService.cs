using System;
using System.Threading.Tasks;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;

namespace Blauhaus.DeviceServices.DeviceInfo
{
    public class DeviceInfoService : IDeviceInfoService
    {
        private string? _deviceId;

        public DeviceInfoService()
        {
            AppDataFolder = Xamarin.Essentials.FileSystem.AppDataDirectory;
        }

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