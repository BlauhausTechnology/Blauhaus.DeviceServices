﻿using System.Threading.Tasks;
using Blauhaus.Responses;

namespace Blauhaus.DeviceServices.Abstractions.Permissions
{
    public interface IDevicePermissionsService
    {

        Task<Response> EnsurePermissionGrantedAsync(DevicePermission permission);
        Task<Response> CheckPermissionAsync(DevicePermission permission);
        Task<Response> RequestPermissionAsync(DevicePermission permission);
    }
}