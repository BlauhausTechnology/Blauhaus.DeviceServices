using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.DeviceServices.Abstractions.Application
{
    public interface IApplicationInfoService
    {
        string CurrentVersion { get; }
    }
}