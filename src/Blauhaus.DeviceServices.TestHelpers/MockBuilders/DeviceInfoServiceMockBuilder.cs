using System;
using Blauhaus.Common.ValueObjects.DeviceType;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;
using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.TestHelpers.MockBuilders;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class DeviceInfoServiceMockBuilder : BaseMockBuilder<DeviceInfoServiceMockBuilder, IDeviceInfoService>
    {
        public DeviceInfoServiceMockBuilder()
        {
            With(x => x.Type, DeviceType.Phone);
            With(x => x.Platform, RuntimePlatform.iOS);
            With(x => x.AppDataFolder, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            With(x => x.DeviceUniqueIdentifier, Guid.NewGuid().ToString());
            With(x => x.Model, "Model T");
            With(x => x.OperatingSystemVersion, "2.0");
            With(x => x.Manufacturer, "Ford");

        }
    }
}