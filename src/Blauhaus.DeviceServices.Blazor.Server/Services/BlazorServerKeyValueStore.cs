using Blauhaus.Analytics.Abstractions;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Common.Abstractions;
using Blauhaus.Errors;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Blauhaus.DeviceServices.Blazor.Server.Services;

public class BlazorServerKeyValueStore : IKeyValueStore
{
    private readonly IAnalyticsLogger<BlazorServerKeyValueStore> _logger;
    private readonly ProtectedLocalStorage _protectedLocalStorage;

    public BlazorServerKeyValueStore(
        IAnalyticsLogger<BlazorServerKeyValueStore> logger,
        ProtectedLocalStorage protectedLocalStorage)
    {
        _logger = logger;
        _protectedLocalStorage = protectedLocalStorage;
    }

    public async Task<string> GetAsync(string key)
    {
        try
        {
            var result = await _protectedLocalStorage.GetAsync<string>(key);
            if (result.Success && result.Value is not null)
            {
                _logger.LogTrace("Retrieved value for {ValueName} from secure storage", key);
                return result.Value;
            }

            _logger.LogInformation("Key {Key} not found in secure storage", key);
            return string.Empty;

        }
        catch (Exception e)
        {
            _logger.LogError(Error.Unexpected($"Failed to retried value with key {key}"), e);
            return string.Empty;
        }
    }

    public async Task SetAsync(string key, string value)
    {
        await _protectedLocalStorage.SetAsync(key, value);
        _logger.LogTrace("Saved value for {Key} to secure storage", key);
    }

    public bool Remove(string key)
    {

        _protectedLocalStorage.DeleteAsync(key);
        _logger.LogTrace("Removed value for {ValueName} from secure storage", (object) key);
        return true;
    }   
}