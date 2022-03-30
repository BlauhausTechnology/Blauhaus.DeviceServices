using System;
using Blauhaus.Errors;
using Blauhaus.Errors.Extensions;

namespace Blauhaus.DeviceServices.Abstractions.Permissions
{
    public static class DevicePermissionErrors
    {
        public static Error PermissionDenied(string permissionName) => Error.Create($"Permission for {permissionName} was denied");
        public static Error PermissionDisabled(string permissionName) => Error.Create($"Permission for {permissionName} could not be granted as the capability is disabled");
        public static Error PermissionRestricted(string permissionName)  => Error.Create($"Permission for {permissionName} is restricted");
        public static Error PermissionUnknown(string permissionName)  => Error.Create($"Status for {permissionName} permission could not be determined ");
        public static Error PermissionException(string permissionName)  => Error.Create($"An error occured while requesting permission for {permissionName}");

        public static bool IsPermissionError(this Error error)
        {
            return error.Code == nameof(PermissionDenied) || 
                   error.Code == nameof(PermissionDisabled) || 
                   error.Code == nameof(PermissionRestricted) || 
                   error.Code == nameof(PermissionUnknown) || 
                   error.Code == nameof(PermissionException);
        }

        public static bool IsPermissionError(this Exception exception)
        {
            return exception.IsErrorException() && exception.ToError().IsPermissionError();
        }

    }

}