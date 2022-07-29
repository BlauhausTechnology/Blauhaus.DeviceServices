using Blauhaus.Common.TestHelpers.MockBuilders;
using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Moq;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class ConnectivityServiceMockBuilder : BaseAsyncPublisherMockBuilder<ConnectivityServiceMockBuilder, IConnectivityService, ConnectionState>
    {
        public ConnectivityServiceMockBuilder()
        {
            With(x => x.IsConnectedToInternet, true);
            With(x => x.IsConnectionUsingCellularData, false);
            With(x => x.CurrentConnection, new ConnectionState(ConnectionAccess.Internet, ConnectionType.Ethernet));
            Where_GetConnectionStateAsync_returns(new ConnectionState(ConnectionAccess.Internet, ConnectionType.Ethernet));
        }

        public ConnectivityServiceMockBuilder Where_GetConnectionStateAsync_returns(ConnectionState state)
        {
            Mock.Setup(x => x.GetConnectionStateAsync())
                .ReturnsAsync(state);
            return this;
        }
         
    }
}