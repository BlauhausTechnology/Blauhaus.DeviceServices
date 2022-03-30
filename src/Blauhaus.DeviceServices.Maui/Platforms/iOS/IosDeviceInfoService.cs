// ReSharper disable CheckNamespace
using Security;

namespace Blauhaus.DeviceServices.Maui;

public class IosDeviceInfoService : BaseDeviceInfoService
{
    public IosDeviceInfoService()
    {
        SecureStorage.DefaultAccessible = SecAccessible.AfterFirstUnlockThisDeviceOnly;
    }
}