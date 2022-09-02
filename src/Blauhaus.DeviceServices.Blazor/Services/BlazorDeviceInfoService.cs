using System.Globalization;
using Blauhaus.Common.ValueObjects.DeviceType;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blazored.LocalStorage;

namespace Blauhaus.DeviceServices.Blazor.Services;

public class BlazorDeviceInfoService : IDeviceInfoService
{
    private readonly ILocalStorageService _localStorageService;
    private string? _deviceId;
    private const string DeviceKey = "DeviceUniqueId";

    public BlazorDeviceInfoService(ILocalStorageService localStorageService)
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
        get
        {
            if (_deviceId == null)
            {
                _deviceId = Task.Run(async () => await _localStorageService.GetItemAsStringAsync(DeviceKey)).GetAwaiter().GetResult();
                if (string.IsNullOrEmpty(_deviceId))
                {
                    _deviceId = Guid.NewGuid().ToString();
                    Task.Run(async ()=> await _localStorageService.SetItemAsStringAsync(DeviceKey, _deviceId)).GetAwaiter().GetResult();
                }
            }
            return _deviceId;
        }
    }
}