using Android.App;
using Android.Provider;

namespace Blauhaus.DeviceServices.Platforms.Android
{
    public partial class DeviceInfoService 
    {
        public string DeviceUniqueIdentifier
        {
            get { return Settings.Secure.GetString(Application.Context.ApplicationContext.ContentResolver, Settings.Secure.AndroidId); }
        }
    }
}