using System.Threading.Tasks;
using Blauhaus.DeviceServices.Common.DeviceInfo;
using Security;
using UIKit;

namespace Blauhaus.DeviceServices.iOS
{
    public class IosDeviceInfoService : BaseDeviceInfoService
    {
        private string? _deviceId;
        private string? _modelName;

        protected override string GetPlatformDeviceId()
        {
            Xamarin.Essentials.SecureStorage.DefaultAccessible = SecAccessible.AlwaysThisDeviceOnly;
            return UIDevice.CurrentDevice.IdentifierForVendor.AsString();
        }

        public override string Model
        {
            get
            {
                if (_modelName == null)
                {
                    _modelName = Xamarin.iOS.DeviceHardware.Model;
                }

                return _modelName;
            }
        }
    }
}