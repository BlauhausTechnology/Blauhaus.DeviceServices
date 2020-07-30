using System.Threading.Tasks;
using Blauhaus.DeviceServices.Common.DeviceInfo;
using Security;
using UIKit;

namespace Blauhaus.DeviceServices.iOS
{
    public class IosDeviceInfoService : BaseDeviceInfoService
    {
        private string? _modelName;

        public IosDeviceInfoService()
        {
            Xamarin.Essentials.SecureStorage.DefaultAccessible = SecAccessible.AlwaysThisDeviceOnly;
        }

        protected override string GetPlatformDeviceId()
        {
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