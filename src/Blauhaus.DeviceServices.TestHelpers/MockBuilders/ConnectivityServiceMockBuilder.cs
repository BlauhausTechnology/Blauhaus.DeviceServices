using Blauhaus.Common.TestHelpers.MockBuilders;
using Blauhaus.DeviceServices.Abstractions.Connectivity;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class ConnectivityServiceMockBuilder : BaseAsyncPublisherMockBuilder<ConnectivityServiceMockBuilder, IConnectivityService, ConnectionState>
    {
        public ConnectivityServiceMockBuilder()
        {
            With(x => x.IsConnectedToInternet, true);
            With(x => x.IsConnectionUsingCellularData, false);
            With(x => x.CurrentConnection, new ConnectionState(ConnectionAccess.Internet, ConnectionType.Ethernet));
        }
         
    }
}