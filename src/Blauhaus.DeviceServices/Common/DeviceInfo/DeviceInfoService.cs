using System;

namespace Blauhaus.DeviceServices.Common.DeviceInfo
{
    public class DeviceInfoService : BaseDeviceInfoService
    {
        protected override string GetPlatformDeviceId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}