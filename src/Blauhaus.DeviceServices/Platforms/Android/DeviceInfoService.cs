using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using System;
using System.Threading.Tasks;

namespace Blauhaus.DeviceServices.Platforms.Android
{
    public partial class DeviceInfoService
    {
        private string? _deviceId;

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
    }
}