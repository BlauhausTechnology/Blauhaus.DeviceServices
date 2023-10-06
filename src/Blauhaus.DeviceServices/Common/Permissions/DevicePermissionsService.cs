using System;
using System.Threading.Tasks;
using Blauhaus.Analytics.Abstractions;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.DeviceServices.Abstractions.Permissions;
using Blauhaus.DeviceServices.Abstractions.Thread;
using Blauhaus.Responses;
using Microsoft.Extensions.Logging;
using Xamarin.Essentials; 

namespace Blauhaus.DeviceServices.Common.Permissions
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

            _logger.LogInformation("Requested {RequestedPermission} permission has not previously been granted. Requesting...", permission);
            return await RequestPermissionAsync(permission);
        }

        public Task<Response> CheckPermissionAsync(DevicePermission permission)
        {
            return permission switch
            {
                DevicePermission.Battery => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Battery>(),
                DevicePermission.CalendarRead => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.CalendarRead>(),
                DevicePermission.CalendarWrite => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.CalendarWrite>(),
                DevicePermission.Camera => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Camera>(),
                DevicePermission.ContactsRead => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.ContactsRead>(),
                DevicePermission.ContactsWrite => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.ContactsWrite>(),
                DevicePermission.Flashlight => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Flashlight>(),
                DevicePermission.LaunchApp => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.LaunchApp>(),
                DevicePermission.LocationWhenInUse => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.LocationWhenInUse>(),
                DevicePermission.LocationAlways => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.LocationAlways>(),
                DevicePermission.Maps => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Maps>(),
                DevicePermission.Media => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Media>(),
                DevicePermission.Microphone => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Microphone>(),
                DevicePermission.NetworkState => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.NetworkState>(),
                DevicePermission.Phone => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Phone>(),
                DevicePermission.Photos => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Photos>(),
                DevicePermission.Reminders => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Reminders>(),
                DevicePermission.Sensors => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Sensors>(),
                DevicePermission.Sms => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Sms>(),
                DevicePermission.Speech => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Speech>(),
                DevicePermission.StorageRead => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.StorageRead>(),
                DevicePermission.StorageWrite => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.StorageWrite>(),
                DevicePermission.Vibrate => CheckPermissionStatusAsync<Xamarin.Essentials.Permissions.Vibrate>(),
                _ => throw new ArgumentOutOfRangeException(nameof(permission), permission, null)
            };
        }

        public Task<Response> RequestPermissionAsync(DevicePermission permission)
        {
            return permission switch
            {
                DevicePermission.Battery => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Battery>(),
                DevicePermission.CalendarRead => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.CalendarRead>(),
                DevicePermission.CalendarWrite => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.CalendarWrite>(),
                DevicePermission.Camera => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Camera>(),
                DevicePermission.ContactsRead => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.ContactsRead>(),
                DevicePermission.ContactsWrite => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.ContactsWrite>(),
                DevicePermission.Flashlight => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Flashlight>(),
                DevicePermission.LaunchApp => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.LaunchApp>(),
                DevicePermission.LocationWhenInUse => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.LocationWhenInUse>(),
                DevicePermission.LocationAlways => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.LocationAlways>(),
                DevicePermission.Maps => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Maps>(),
                DevicePermission.Media => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Media>(),
                DevicePermission.Microphone => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Microphone>(),
                DevicePermission.NetworkState => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.NetworkState>(),
                DevicePermission.Phone => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Phone>(),
                DevicePermission.Photos => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Photos>(),
                DevicePermission.Reminders => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Reminders>(),
                DevicePermission.Sensors => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Sensors>(),
                DevicePermission.Sms => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Sms>(),
                DevicePermission.Speech => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Speech>(),
                DevicePermission.StorageRead => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.StorageRead>(),
                DevicePermission.StorageWrite => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.StorageWrite>(),
                DevicePermission.Vibrate => RequestPermissionStatusAsync<Xamarin.Essentials.Permissions.Vibrate>(),
                _ => throw new ArgumentOutOfRangeException(nameof(permission), permission, null)
            };
        }

        private async Task<Response> RequestPermissionStatusAsync<T>() where T : Xamarin.Essentials.Permissions.BasePermission, new()
        {
            return await _threadService.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var permissionStatus = await Xamarin.Essentials.Permissions.RequestAsync<T>();

                    if (permissionStatus == PermissionStatus.Granted)
                    {
                        _logger.LogInformation("Permission granted for {Permission}", typeof(T).Name);
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

        private async Task<Response> CheckPermissionStatusAsync<T>() where T : Xamarin.Essentials.Permissions.BasePermission, new()
        {
            return await _threadService.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    var permissionStatus = await Xamarin.Essentials.Permissions.CheckStatusAsync<T>();
                    if (permissionStatus == PermissionStatus.Granted)
                    {
                        _logger.LogDebug("Permission has already been granted for {Permission}",typeof(T).Name);
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