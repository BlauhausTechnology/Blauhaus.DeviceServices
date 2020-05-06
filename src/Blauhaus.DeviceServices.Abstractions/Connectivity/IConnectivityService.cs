namespace Blauhaus.DeviceServices.Abstractions.Connectivity
{
    public interface IConnectivityService
    {
        bool IsConnectedToInternet { get; }
        bool IsConnectionUsingCellularData { get; }
}
}