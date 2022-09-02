using Blauhaus.Analytics.Abstractions;
using Blauhaus.Common.Abstractions;
using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;

namespace Blauhaus.DeviceServices.Blazor.Services;

public class BlazorLocalStorageService : IKeyValueProvider
{
    private readonly IAnalyticsLogger<BlazorLocalStorageService> _logger;
    private readonly ILocalStorageService _localStorageService;

    public BlazorLocalStorageService(
        IAnalyticsLogger<BlazorLocalStorageService> logger,
        ILocalStorageService localStorageService)
    {
        _logger = logger;
        _localStorageService = localStorageService;
    }

    public async Task<string> GetAsync(string key)
    {
        _logger.LogTrace("Retrieved value for {ValueName} from secure storage", key);
        return await _localStorageService.GetItemAsStringAsync(key);
    }

    public async Task SetAsync(string key, string value)
    {
        _logger.LogTrace("Saved value for {ValueName} to secure storage", key);
        await _localStorageService.SetItemAsStringAsync(key, value);
    }

    public bool Remove(string key)
    {
        _logger.LogTrace("Removed value for {ValueName} from secure storage", key);
        _localStorageService.RemoveItemAsync(key);
        return true;
    }
     
}