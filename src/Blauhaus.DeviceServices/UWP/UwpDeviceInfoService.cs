using Windows.Storage.Streams;
using Windows.System.Profile;
using Blauhaus.DeviceServices.Common.DeviceInfo;

namespace Blauhaus.DeviceServices.UWP
{
    public class UwpDeviceInfoService : BaseDeviceInfoService
    {
        private string? _deviceId;

        public override string DeviceUniqueIdentifier
        {
            get
            {
                if (_deviceId == null)
                {
                    var systemId = SystemIdentification.GetSystemIdForPublisher();
                    var dataReader = DataReader.FromBuffer(systemId.Id);
                    _deviceId = dataReader.ReadGuid().ToString();
                }
                return _deviceId;
            }
        }
    }
}