using Blauhaus.DeviceServices.Abstractions.Application;

namespace Blauhaus.DeviceServices.Blazor.Services;

public class BlazorApplicationInfoService : IApplicationInfoService
{
    public string CurrentVersion { get; } = "Unknown"; 
}