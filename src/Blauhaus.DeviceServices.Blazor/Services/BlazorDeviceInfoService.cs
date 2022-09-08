using System.Globalization;
using Blauhaus.Common.ValueObjects.DeviceType;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blazored.LocalStorage;

namespace Blauhaus.DeviceServices.Blazor.Services;

public class BlazorDeviceInfoService : IDeviceInfoService
{
    private readonly ISyncLocalStorageService _localStorageService;
    private string? _deviceId;
    private const string DeviceKey = "DeviceUniqueId";

    public BlazorDeviceInfoService(ISyncLocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public IDeviceType Type { get; } = DeviceType.Unknown;
    public IRuntimePlatform Platform { get; } = RuntimePlatform.Unknown;
    public string OperatingSystemVersion { get; } = "Unknown";
    public string Manufacturer { get; }= "Unknown";
    public string Model { get; } = "Unknown";
    public string AppDataFolder { get; }= "Unknown";
    public CultureInfo CurrentCulture => CultureInfo.CurrentUICulture;
     
    public string DeviceUniqueIdentifier
    {
        get { return _deviceId ??= Task.Run(async () => await GetDeviceIdentifierAsync()).GetAwaiter().GetResult(); }
    }

    public ValueTask<string> GetDeviceIdentifierAsync()
    {
        if (_deviceId == null)
        {
            _deviceId = _localStorageService.GetItemAsString(DeviceKey);
            if (string.IsNullOrEmpty(_deviceId))
            {
                _deviceId = Guid.NewGuid().ToString();
                _localStorageService.SetItemAsString(DeviceKey, _deviceId);
            }
        }
        return new ValueTask<string>(_deviceId);
    }
}