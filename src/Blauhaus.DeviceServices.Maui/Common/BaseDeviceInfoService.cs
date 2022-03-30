using Blauhaus.Common.ValueObjects.DeviceType;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using DeviceType = Blauhaus.Common.ValueObjects.DeviceType.DeviceType;
// ReSharper disable CheckNamespace

namespace Blauhaus.DeviceServices.Maui;

public class DeviceInfoService : BaseDeviceInfoService
{
}

public abstract class BaseDeviceInfoService : IDeviceInfoService
{
    private string? _deviceId;
    private const string DeviceKey = "DeviceUniqueId";

    protected BaseDeviceInfoService()
    {
        AppDataFolder = FileSystem.AppDataDirectory;

        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
            Type = DeviceType.Phone;
        else if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
            Type = DeviceType.Tablet;
        else if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
            Type = DeviceType.PC;
        else if (DeviceInfo.Idiom == DeviceIdiom.TV)
            Type = DeviceType.TV;
        else if (DeviceInfo.Idiom == DeviceIdiom.Watch)
            Type = DeviceType.Watch;
        else
        {
            Type = DeviceType.Unknown;
        }

        Manufacturer = DeviceInfo.Manufacturer;
        OperatingSystemVersion = DeviceInfo.VersionString;

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            Platform = RuntimePlatform.Android;
        }
        else if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            Platform = RuntimePlatform.iOS;
        }
        else if (DeviceInfo.Platform == DevicePlatform.WinUI || DeviceInfo.Platform == DevicePlatform.UWP)
        {
            Platform = RuntimePlatform.Windows;
        }
        else if (DeviceInfo.Platform == DevicePlatform.MacCatalyst || DeviceInfo.Platform == DevicePlatform.macOS)
        {
            Platform = RuntimePlatform.Mac;
        }
        else
        {
            Platform = RuntimePlatform.Unknown;
        }
    }

    public IDeviceType Type { get; }
    public IRuntimePlatform Platform { get; }
    public string OperatingSystemVersion { get; }
    public string Manufacturer { get; }
    public virtual string Model => DeviceInfo.Model;

    public string AppDataFolder { get; }

    public string DeviceUniqueIdentifier
    {
        get
        {
            if (_deviceId == null)
            {
                _deviceId = Task.Run(() => SecureStorage.GetAsync(DeviceKey)).GetAwaiter().GetResult();
                if (string.IsNullOrEmpty(_deviceId))
                {
                    _deviceId = Guid.NewGuid().ToString();
                    SecureStorage.SetAsync(DeviceKey, _deviceId);
                }
            }
            return _deviceId;
        }
    }
}