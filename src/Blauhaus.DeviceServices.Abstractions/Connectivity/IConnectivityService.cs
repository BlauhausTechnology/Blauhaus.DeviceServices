using System;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.DeviceServices.Abstractions.Connectivity
{
    public interface IConnectivityService : IAsyncPublisher<ConnectionState>
    {
        bool IsConnectedToInternet { get; }
        bool IsConnectionUsingCellularData { get; }

        ConnectionState CurrentConnection { get; }
    }
}