using Blauhaus.Errors;

namespace Blauhaus.DeviceServices.Abstractions.Permissions
{
    public static class DevicePermissionErrors
    {
        public static Error Denied(string permissionName) => Error.Create($"Permission for {permissionName} was denied");
        public static Error Disabled(string permissionName) => Error.Create($"Permission for {permissionName} could not be granted as the capability is disabled");
        public static Error Restricted(string permissionName)  => Error.Create($"Permission for {permissionName} is restricted");
        public static Error Unknown(string permissionName)  => Error.Create($"Status for {permissionName} permission could not be determined ");
        public static Error Exception(string permissionName, string exceptionMessage)  => Error.Create($"An error occured while requesting permission for {permissionName}. The error message was {exceptionMessage}");
    }
}