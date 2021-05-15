using System;
using System.Linq;
using System.Threading.Tasks;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.Common.Utils.Disposables;
using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Xamarin.Essentials;

namespace Blauhaus.DeviceServices.Common.Connectivity
{
    public class ConnectivityService : BasePublisher, IConnectivityService
    {
        private readonly IAnalyticsService _analyticsService;
        private ConnectionAccess _previousNetworkAccess = ConnectionAccess.Unknown;

        public ConnectivityService(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;

            Xamarin.Essentials.Connectivity.ConnectivityChanged += HandleConnectivityChanged;
        }

        public Task<IDisposable> SubscribeAsync(Func<ConnectionState, Task> handler, Func<ConnectionState, bool>? filter = null)
        {
            return Task.FromResult(AddSubscriber(handler, filter));
        }
       
        public bool IsConnectedToInternet 
            => Xamarin.Essentials.Connectivity.NetworkAccess == NetworkAccess.Internet;
           
        public bool IsConnectionUsingCellularData 
            => Xamarin.Essentials.Connectivity.NetworkAccess == NetworkAccess.Internet 
               && Xamarin.Essentials.Connectivity.ConnectionProfiles.Contains(ConnectionProfile.Cellular);

        public ConnectionState CurrentConnection => GetState();
         
        private async void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var newConnectionState = GetState();
            if (newConnectionState.Access != _previousNetworkAccess)
            {
                _analyticsService.Trace(this, $"Network access changed from {_previousNetworkAccess} to {newConnectionState.Access}", LogSeverity.Verbose, newConnectionState.Types.ToObjectDictionary());
                await UpdateSubscribersAsync(newConnectionState);
                _previousNetworkAccess = newConnectionState.Access;
            }
            
        }

        private static ConnectionState GetState()
        {
            return new ConnectionState(
                (ConnectionAccess) Xamarin.Essentials.Connectivity.NetworkAccess, 
                Xamarin.Essentials.Connectivity.ConnectionProfiles.Select(x => (ConnectionType)x));
        }
         
    }
}