using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;

namespace Blauhaus.DeviceServices.TestHelpers.Dummies
{
    public class DummySecureStorageService : ISecureStorageService
    {

        private readonly Dictionary<string, string> _insecureStorage = new Dictionary<string, string>();

        public Task<string> GetAsync(string key)
        {
            _insecureStorage.TryGetValue(key, out var maybeValue);
            return Task.FromResult(maybeValue);
        }

        public Task SetAsync(string key, string value)
        {
            _insecureStorage[key] = value;
            return Task.CompletedTask;
        }
 
        public bool Remove(string key)
        {
            if (_insecureStorage.ContainsKey(key))
            {
                _insecureStorage.Remove(key);
                return true;
            }
            return false;
        }
    }
}