using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Blauhaus.TestHelpers.MockBuilders;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class ConnectivityServiceMockBuilder : BaseMockBuilder<ConnectivityServiceMockBuilder, IConnectivityService>
    {
        public ConnectivityServiceMockBuilder()
        {
            With(x => x.IsConnectedToInternet, true);
            With(x => x.IsConnectionUsingCellularData, false);
        }
    }
}