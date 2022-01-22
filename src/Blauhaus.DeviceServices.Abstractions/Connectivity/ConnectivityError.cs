using Blauhaus.Errors;

namespace Blauhaus.DeviceServices.Abstractions.Connectivity
{
    public static class ConnectivityError
    {
        public static Error NotConnected = Error.Create("No internet connection");
    }
}