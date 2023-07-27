// ReSharper disable CheckNamespace
using static Android.Provider.Settings;

namespace Blauhaus.DeviceServices.Maui;
public class AndroidDeviceInfoService : BaseDeviceInfoService
{
    protected override string? GetDeviceIdForPlatform()
    {
        var context = Android.App.Application.Context;
        string? id = Secure.GetString(context.ContentResolver, Secure.AndroidId);
        return id ?? base.GetDeviceIdForPlatform();
    }
}

