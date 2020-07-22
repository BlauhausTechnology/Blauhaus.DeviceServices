using System;

namespace Blauhaus.DeviceServices.Abstractions.Connectivity
{
    public interface IConnectivityService
    {
        bool IsConnectedToInternet { get; }
        bool IsConnectionUsingCellularData { get; }

        ConnectionState CurrentConnection { get; }
        IObservable<ConnectionState> Connect();
    }
}