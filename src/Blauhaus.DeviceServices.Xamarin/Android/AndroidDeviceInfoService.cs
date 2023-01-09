using Android.App;
using Android.Provider;
using Blauhaus.DeviceServices.Common.DeviceInfo;

namespace Blauhaus.DeviceServices.Android
{
    public class AndroidDeviceInfoService : BaseDeviceInfoService
    {
        private string? _modelName;

        public override string Model
        {
            get
            {
                if (_modelName == null)
                {
                    _modelName = GetDroidModel.DeviceHardware.GetModel(defaultValue: "Unknown", includeManufacturer: true);
                    if (_modelName == "Unknown")
                    {
                        //_modelName = Xamarin.Essentials.DeviceInfo.Model;
                    }
                }
                return _modelName;
            }
        }

        protected override string GetPlatformDeviceId()
        {
            return Settings.Secure.GetString(Application.Context.ApplicationContext!.ContentResolver, Settings.Secure.AndroidId)!;
        }

    }
    
}