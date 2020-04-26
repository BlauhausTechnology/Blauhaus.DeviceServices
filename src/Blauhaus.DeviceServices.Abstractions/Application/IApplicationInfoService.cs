using System.Threading.Tasks;

namespace Blauhaus.DeviceServices.Abstractions.Application
{
    public interface IApplicationInfoService
    {
        string CurrentVersion { get; }
    }
}