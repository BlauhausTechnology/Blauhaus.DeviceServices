using System;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.DeviceServices.Abstractions.Connectivity
{
    public interface IConnectivityService : IAsyncPublisher<ConnectionState>
    {
        bool IsConnectedToInternet { get; }
        bool IsConnectionUsingCellularData { get; }

        ValueTask<ConnectionState> GetConnectionStateAsync();

        ConnectionState CurrentConnection { get; }
    }
}