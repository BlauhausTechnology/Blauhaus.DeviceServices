using Blauhaus.Analytics.Abstractions;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.DeviceServices.Abstractions.Permissions;
using Blauhaus.DeviceServices.Abstractions.Thread;
using Blauhaus.Responses;
using Microsoft.Extensions.Logging;

namespace Blauhaus.DeviceServices.Maui
{
    public class DevicePermissionsService : IDevicePermissionsService
    {
        private readonly IAnalyticsLogger<DevicePermissionsService> _logger;
        private readonly IThreadService _threadService;

        public DevicePermissionsService(
            IAnalyticsLogger<DevicePermissionsService> logger,
            IThreadService threadService)
        {
            _logger = logger;
            _threadService = threadService;
        }


        public async Task<Response> EnsurePermissionGrantedAsync(DevicePermission permission)
        {
            var permissionAlreadyGranted = await CheckPermissionAsync(permission);
            if (permissionAlreadyGranted.IsSuccess)
            {
                return Response.Success();
            }

            _logger.LogInformation("Requested permission {DevicePermission} has not previously been granted. Requesting...", permission);
            return await RequestPermissionAsync(permission);
        }

        public Task<Response> CheckPermissionAsync(DevicePermission permission)
        {
            return permission switch
            {
                DevicePermission.Battery => CheckPermissionStatusAsync<Permissions.Battery>(),
                DevicePermission.CalendarRead => CheckPermissionStatusAsync<Permissions.CalendarRead>(),
                DevicePermission.CalendarWrite => CheckPermissionStatusAsync<Permissions.CalendarWrite>(),
                DevicePermission.Camera => CheckPermissionStatusAsync<Permissions.Camera>(),
                DevicePermission.ContactsRead => CheckPermissionStatusAsync<Permissions.ContactsRead>(),
                DevicePermission.ContactsWrite => CheckPermissionStatusAsync<Permissions.ContactsWrite>(),
                DevicePermission.Flashlight => CheckPermissionStatusAsync<Permissions.Flashlight>(),
                DevicePermission.LaunchApp => CheckPermissionStatusAsync<Permissions.LaunchApp>(),
                DevicePermission.LocationWhenInUse => CheckPermissionStatusAsync<Permissions.LocationWhenInUse>(),
                DevicePermission.LocationAlways => CheckPermissionStatusAsync<Permissions.LocationAlways>(),
                DevicePermission.Maps => CheckPermissionStatusAsync<Permissions.Maps>(),
                DevicePermission.Media => CheckPermissionStatusAsync<Permissions.Media>(),
                DevicePermission.Microphone => CheckPermissionStatusAsync<Permissions.Microphone>(),
                DevicePermission.NetworkState => CheckPermissionStatusAsync<Permissions.NetworkState>(),
                DevicePermission.Phone => CheckPermissionStatusAsync<Permissions.Phone>(),
                DevicePermission.Photos => CheckPermissionStatusAsync<Permissions.Photos>(),
                DevicePermission.Reminders => CheckPermissionStatusAsync<Permissions.Reminders>(),
                DevicePermission.Sensors => CheckPermissionStatusAsync<Permissions.Sensors>(),
                DevicePermission.Sms => CheckPermissionStatusAsync<Permissions.Sms>(),
                DevicePermission.Speech => CheckPermissionStatusAsync<Permissions.Speech>(),
                DevicePermission.StorageRead => CheckPermissionStatusAsync<Permissions.StorageRead>(),
                DevicePermission.StorageWrite => CheckPermissionStatusAsync<Permissions.StorageWrite>(),
                DevicePermission.Vibrate => CheckPermissionStatusAsync<Permissions.Vibrate>(),
                _ => throw new ArgumentOutOfRangeException(nameof(permission), permission, null)
            };
        }

        public Task<Response> RequestPermissionAsync(DevicePermission permission)
        {
            return permission switch
            {
                DevicePermission.Battery => RequestPermissionStatusAsync<Permissions.Battery>(),
                DevicePermission.CalendarRead => RequestPermissionStatusAsync<Permissions.CalendarRead>(),
                DevicePermission.CalendarWrite => RequestPermissionStatusAsync<Permissions.CalendarWrite>(),
                DevicePermission.Camera => RequestPermissionStatusAsync<Permissions.Camera>(),
                DevicePermission.ContactsRead => RequestPermissionStatusAsync<Permissions.ContactsRead>(),
                DevicePermission.ContactsWrite => RequestPermissionStatusAsync<Permissions.ContactsWrite>(),
                DevicePermission.Flashlight => RequestPermissionStatusAsync<Permissions.Flashlight>(),
                DevicePermission.LaunchApp => RequestPermissionStatusAsync<Permissions.LaunchApp>(),
                DevicePermission.LocationWhenInUse => RequestPermissionStatusAsync<Permissions.LocationWhenInUse>(),
                DevicePermission.LocationAlways => RequestPermissionStatusAsync<Permissions.LocationAlways>(),
                DevicePermission.Maps => RequestPermissionStatusAsync<Permissions.Maps>(),
                DevicePermission.Media => RequestPermissionStatusAsync<Permissions.Media>(),
                DevicePermission.Microphone => RequestPermissionStatusAsync<Permissions.Microphone>(),
                DevicePermission.NetworkState => RequestPermissionStatusAsync<Permissions.NetworkState>(),
                DevicePermission.Phone => RequestPermissionStatusAsync<Permissions.Phone>(),
                DevicePermission.Photos => RequestPermissionStatusAsync<Permissions.Photos>(),
                DevicePermission.Reminders => RequestPermissionStatusAsync<Permissions.Reminders>(),
                DevicePermission.Sensors => RequestPermissionStatusAsync<Permissions.Sensors>(),
                DevicePermission.Sms => RequestPermissionStatusAsync<Permissions.Sms>(),
                DevicePermission.Speech => RequestPermissionStatusAsync<Permissions.Speech>(),
                DevicePermission.StorageRead => RequestPermissionStatusAsync<Permissions.StorageRead>(),
                DevicePermission.StorageWrite => RequestPermissionStatusAsync<Permissions.StorageWrite>(),
                DevicePermission.Vibrate => RequestPermissionStatusAsync<Permissions.Vibrate>(),
                _ => throw new ArgumentOutOfRangeException(nameof(permission), permission, null)
            };
        }

        private async Task<Response> RequestPermissionStatusAsync<T>() where T : Permissions.BasePermission, new()
        {
            return await _threadService.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var permissionStatus = await Permissions.RequestAsync<T>();

                    if (permissionStatus == PermissionStatus.Granted)
                    {
                        _logger.LogInformation("Permission granted for {DevicePermission}", typeof(T).Name);
                        return Response.Success();
                    }

                    return permissionStatus switch
                    {
                        PermissionStatus.Denied => _logger.LogErrorResponse(DevicePermissionErrors.PermissionDenied(typeof(T).Name)),
                        PermissionStatus.Disabled => _logger.LogErrorResponse(DevicePermissionErrors.PermissionDisabled(typeof(T).Name)),
                        PermissionStatus.Restricted => _logger.LogErrorResponse(DevicePermissionErrors.PermissionRestricted(typeof(T).Name)),
                        _ => _logger.LogErrorResponse(DevicePermissionErrors.PermissionUnknown(typeof(T).Name))
                    };
                }
                catch (Exception e)
                {
                    return _logger.LogErrorResponse(DevicePermissionErrors.PermissionException(typeof(T).Name), e);
                }
            });

        }

        private async Task<Response> CheckPermissionStatusAsync<T>() where T : Permissions.BasePermission, new()
        {
            return await _threadService.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var permissionStatus = await Permissions.CheckStatusAsync<T>();
                    if (permissionStatus == PermissionStatus.Granted)
                    {
                        _logger.LogDebug("Permission has already been granted for {DevicePermission}", typeof(T).Name);
                        return Response.Success();
                    }

                    return permissionStatus switch
                    {
                        PermissionStatus.Denied => _logger.LogErrorResponse(DevicePermissionErrors.PermissionDenied(typeof(T).Name)),
                        PermissionStatus.Disabled => _logger.LogErrorResponse(DevicePermissionErrors.PermissionDisabled(typeof(T).Name)),
                        PermissionStatus.Restricted => _logger.LogErrorResponse(DevicePermissionErrors.PermissionRestricted(typeof(T).Name)),
                        _ => _logger.LogErrorResponse(DevicePermissionErrors.PermissionUnknown(typeof(T).Name))
                    };
                }
                catch (Exception e)
                {
                    return _logger.LogErrorResponse(DevicePermissionErrors.PermissionException(typeof(T).Name), e);
                }
            });
        }
    }
}