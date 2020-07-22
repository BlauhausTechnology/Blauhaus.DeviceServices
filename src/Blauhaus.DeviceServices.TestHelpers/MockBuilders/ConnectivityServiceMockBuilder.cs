using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
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
            With(x => x.CurrentConnection, new ConnectionState(ConnectionAccess.Internet, ConnectionType.Ethernet));
            Where_Connect_returns(new ConnectionState(ConnectionAccess.Internet, ConnectionType.Ethernet));
        }

        public ConnectivityServiceMockBuilder Where_Connect_returns(IEnumerable<ConnectionState> values)
        {
            Mock.Setup(x => x.Connect()).Returns(Observable.Create<ConnectionState>(observer =>
            {
                foreach (var connectionState in values)
                {
                    observer.OnNext(connectionState);
                }

                return Disposable.Empty;
            }));

            return this;
        }
        
        public ConnectivityServiceMockBuilder Where_Connect_returns(params ConnectionState[] values)
        {
            Mock.Setup(x => x.Connect()).Returns(Observable.Create<ConnectionState>(observer =>
            {
                foreach (var connectionState in values)
                {
                    observer.OnNext(connectionState);
                }

                return Disposable.Empty;
            }));

            return this;
        }

        
        public ConnectivityServiceMockBuilder Where_Connect_returns(Exception e)
        {
            Mock.Setup(x => x.Connect()).Returns(Observable.Create<ConnectionState>(observer =>
            {
                observer.OnError(e);
                return Disposable.Empty;
            }));

            return this;
        }

    }
}