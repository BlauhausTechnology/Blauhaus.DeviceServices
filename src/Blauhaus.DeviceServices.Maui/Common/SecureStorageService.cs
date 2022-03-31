using Blauhaus.Analytics.Abstractions;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Microsoft.Extensions.Logging;

namespace Blauhaus.DeviceServices.Maui
{
    public class SecureStorageService : ISecureStorageService
    {
        private readonly IAnalyticsLogger<SecureStorageService> _logger;

        public SecureStorageService(IAnalyticsLogger<SecureStorageService> logger)
        {
            _logger = logger;
        }

        public Task<string> GetAsync(string key)
        {
            _logger.LogTrace("Retrieved value for {ValueName} from secure storage", key);
            return SecureStorage.GetAsync(key);
        }

        public Task SetAsync(string key, string value)
        {
            _logger.LogTrace("Saved value for {ValueName} to secure storage", key);
            return SecureStorage.SetAsync(key, value);
        }

        public bool Remove(string key)
        {
            _logger.LogTrace("Removed value for {ValueName} from secure storage", key);
            return SecureStorage.Remove(key);
        }

    }
}