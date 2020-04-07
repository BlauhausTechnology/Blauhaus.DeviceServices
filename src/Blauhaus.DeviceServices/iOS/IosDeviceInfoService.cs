using System.Threading.Tasks;
using Blauhaus.DeviceServices.Common.DeviceInfo;
using Security;
using UIKit;

namespace Blauhaus.DeviceServices.iOS
{
    public class IosDeviceInfoService : BaseDeviceInfoService
    {
        private string? _deviceId;

        public override string DeviceUniqueIdentifier
        {
            get
            {
                if (_deviceId == null)
                {
                    _deviceId = Task.Run(() => Xamarin.Essentials.SecureStorage.GetAsync(DeviceKey)).GetAwaiter().GetResult();
                    if (string.IsNullOrEmpty(_deviceId))
                    {
                        Xamarin.Essentials.SecureStorage.DefaultAccessible = SecAccessible.AlwaysThisDeviceOnly;
                        
                        _deviceId = UIDevice.CurrentDevice.IdentifierForVendor.AsString();
                        
                        Xamarin.Essentials.SecureStorage.SetAsync(DeviceKey, DeviceUniqueIdentifier);
                    }
                }
                return _deviceId;
            }
        }
    }
}