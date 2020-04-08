using Android.App;
using Android.Provider;
using Blauhaus.DeviceServices.Common.DeviceInfo;

namespace Blauhaus.DeviceServices.Android
{
    public class AndroidDeviceInfoService : BaseDeviceInfoService
    {
        public override string DeviceUniqueIdentifier => 
            Settings.Secure.GetString(Application.Context.ApplicationContext.ContentResolver, Settings.Secure.AndroidId);
    }
}