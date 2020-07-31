using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Blauhaus.DeviceServices.Abstractions.Permissions
{
    public interface IDevicePermissionsService
    {

        Task<Result> EnsurePermissionGrantedAsync(DevicePermission permission);
        Task<Result> CheckPermissionAsync(DevicePermission permission);
        Task<Result> RequestPermissionAsync(DevicePermission permission);
    }
}