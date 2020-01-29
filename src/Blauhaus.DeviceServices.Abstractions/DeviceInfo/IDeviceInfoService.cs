using System.Threading.Tasks;

namespace Blauhaus.DeviceServices.Abstractions.DeviceInfo
{
    public interface IDeviceInfoService
    {
        string DeviceUniqueIdentifier { get; }
        string AppDataFolder { get; }
    }
}