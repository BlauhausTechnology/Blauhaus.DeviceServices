using Blauhaus.DeviceServices.Abstractions.SecureStorage;

namespace Blauhaus.DeviceServices.Maui
{
    public class SecureStorageService : ISecureStorageService
    {
        public Task<string> GetAsync(string key)
        {
            return Microsoft.Maui.Essentials.SecureStorage.GetAsync(key);
        }

        public Task SetAsync(string key, string value)
        {
            return Microsoft.Maui.Essentials.SecureStorage.SetAsync(key, value);
        }

        public bool Remove(string key)
        {
            return Microsoft.Maui.Essentials.SecureStorage.Remove(key);
        }

    }
}