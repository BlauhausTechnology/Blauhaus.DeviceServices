using System.Threading.Tasks;

namespace Blauhaus.DeviceServices.Abstractions.SecureStorage
{
    public interface ISecureStorageService
    {
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string value);
        bool Remove(string key);
    }
}