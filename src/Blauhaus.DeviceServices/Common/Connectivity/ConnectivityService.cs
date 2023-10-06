using System;
using System.Linq;
using System.Threading.Tasks;
using Blauhaus.Analytics.Abstractions;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.Common.Utils.Disposables;
using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Microsoft.Extensions.Logging;
using Xamarin.Essentials;

namespace Blauhaus.DeviceServices.Common.Connectivity
{
    public class ConnectivityService : BasePublisher, IConnectivityService
    {
        private readonly IAnalyticsLogger<ConnectivityService> _logger;
        private ConnectionAccess _previousNetworkAccess = ConnectionAccess.Unknown;

        public ConnectivityService(IAnalyticsLogger<ConnectivityService> logger)
        {
            _logger = logger;

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

        public ValueTask<ConnectionState> GetConnectionStateAsync()
        {
            return new ValueTask<ConnectionState>(GetState());
        }

        public ConnectionState CurrentConnection => GetState();
         
        private async void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var newConnectionState = GetState();
            if (newConnectionState.Access != _previousNetworkAccess)
            {
                _logger.LogDebug("Network access changed from {PreviousAccess} to {NewAccess}", 
                    _previousNetworkAccess, newConnectionState.Access);

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