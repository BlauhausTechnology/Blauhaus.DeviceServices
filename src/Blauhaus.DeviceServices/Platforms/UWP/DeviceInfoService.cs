using Windows.Storage.Streams;
using Windows.System.Profile;

namespace Blauhaus.DeviceServices.Platforms.UWP
{
    public partial class DeviceInfoService
    {
        private string? _deviceId;

        public string DeviceUniqueIdentifier
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