using System.Linq;
using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Xamarin.Essentials;

namespace Blauhaus.DeviceServices.Common.Connectivity
{
    public class ConnectivityService : IConnectivityService
    {
        public bool IsConnectedToInternet 
            => Xamarin.Essentials.Connectivity.NetworkAccess == NetworkAccess.Internet;
           
        public bool IsConnectionUsingCellularData 
            => Xamarin.Essentials.Connectivity.NetworkAccess == NetworkAccess.Internet 
               && Xamarin.Essentials.Connectivity.ConnectionProfiles.Contains(ConnectionProfile.Cellular);
    }
}