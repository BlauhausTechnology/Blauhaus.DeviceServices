using Blauhaus.DeviceServices.Abstractions.Application;
using Blauhaus.TestHelpers.MockBuilders;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class ApplicationInfoServiceMockBuilder : BaseMockBuilder<ApplicationInfoServiceMockBuilder, IApplicationInfoService>
    {
        public ApplicationInfoServiceMockBuilder()
        {
            With(x => x.CurrentVersion, "0.0.1");
        }
    }
}