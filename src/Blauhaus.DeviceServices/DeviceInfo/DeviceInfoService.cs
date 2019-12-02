using System;
using System.Threading.Tasks;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;

namespace Blauhaus.DeviceServices.DeviceInfo
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public DeviceInfoService()
        {
            Task.Run(async () =>
            {
                DeviceUniqueIdentifier = await Xamarin.Essentials.SecureStorage.GetAsync("DeviceUniqueIdentifier");
                if (string.IsNullOrEmpty(DeviceUniqueIdentifier))
                {
                    DeviceUniqueIdentifier = Guid.NewGuid().ToString();
                    await Xamarin.Essentials.SecureStorage.SetAsync("DeviceUniqueIdentifier", DeviceUniqueIdentifier);
                }
            });

            AppDataFolder = Xamarin.Essentials.FileSystem.AppDataDirectory;
        }

        public string DeviceUniqueIdentifier { get; private set; }
        public string AppDataFolder { get; }
    }
}