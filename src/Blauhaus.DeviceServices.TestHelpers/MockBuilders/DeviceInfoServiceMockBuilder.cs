using System;
using Blauhaus.Common.ValueObjects.DeviceType;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class DeviceInfoServiceMockBuilder : BaseMockBuilder<DeviceInfoServiceMockBuilder, IDeviceInfoService>
    {
        public DeviceInfoServiceMockBuilder()
        {
            var deviceId = Guid.NewGuid().ToString();

            With(x => x.Type, DeviceType.Phone);
            With(x => x.Platform, RuntimePlatform.iOS);
            With(x => x.AppDataFolder, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            With(x => x.DeviceUniqueIdentifier, deviceId);
            With(x => x.Model, "Model T");
            With(x => x.OperatingSystemVersion, "2.0");
            With(x => x.Manufacturer, "Ford");

            Where_GetDeviceIdentifierAsync_returns(deviceId);

        }

        public DeviceInfoServiceMockBuilder Where_GetDeviceIdentifierAsync_returns(string id)
        {
            Mock.Setup(x => x.GetDeviceIdentifierAsync()).ReturnsAsync(id);
            return this;
        }
    }
}