using Blauhaus.DeviceServices.Abstractions.Application;

namespace Blauhaus.DeviceServices.Maui;

public class ApplicationInfoService : IApplicationInfoService
{
    public string CurrentVersion => VersionTracking.CurrentVersion;
       
}
