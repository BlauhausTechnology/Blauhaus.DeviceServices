using Windows.Storage.Streams;
using Windows.System.Profile;
using Blauhaus.DeviceServices.Common.DeviceInfo;

namespace Blauhaus.DeviceServices.UWP
{
    public class UwpDeviceInfoService : BaseDeviceInfoService
    {
        private string? _deviceId;
        private string _modelName;
        
        protected override string GetPlatformDeviceId()
        {
            var systemId = SystemIdentification.GetSystemIdForPublisher();
            var dataReader = DataReader.FromBuffer(systemId.Id);
            return dataReader.ReadGuid().ToString();
        }
        
        public override string Model
        {
            get
            {
                if (_modelName == null)
                {
                    _modelName = Xamarin.Essentials.DeviceInfo.Model;
                }

                return _modelName;
            }
        }
    
    }
}