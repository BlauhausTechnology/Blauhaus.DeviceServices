using System.Threading.Tasks;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;

namespace Blauhaus.DeviceServices.Common.SecureStorage
{
    public class SecureStorageService : ISecureStorageService
    {
        public Task<string> GetAsync(string key)
        {
            return Xamarin.Essentials.SecureStorage.GetAsync(key);
        }

        public Task SetAsync(string key, string value)
        {
            return Xamarin.Essentials.SecureStorage.SetAsync(key, value);
        }

        public bool Remove(string key)
        {
            return Xamarin.Essentials.SecureStorage.Remove(key);
        }

    }
}