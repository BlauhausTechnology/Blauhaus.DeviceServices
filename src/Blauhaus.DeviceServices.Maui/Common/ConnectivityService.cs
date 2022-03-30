using Blauhaus.Analytics.Abstractions;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.Common.Utils.Disposables;
using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Microsoft.Extensions.Logging;

namespace Blauhaus.DeviceServices.Maui
{
    public class ConnectivityService : BasePublisher, IConnectivityService
    {
        private readonly IAnalyticsLogger<ConnectivityService> _logger;
        private ConnectionAccess _previousNetworkAccess = ConnectionAccess.Unknown;

        public ConnectivityService(IAnalyticsLogger<ConnectivityService> logger)
        {
            _logger = logger;

            Connectivity.ConnectivityChanged += HandleConnectivityChanged;
        }

        public Task<IDisposable> SubscribeAsync(Func<ConnectionState, Task> handler, Func<ConnectionState, bool>? filter = null)
        {
            return Task.FromResult(AddSubscriber(handler, filter));
        }
       
        public bool IsConnectedToInternet 
            => Connectivity.NetworkAccess == NetworkAccess.Internet;
           
        public bool IsConnectionUsingCellularData 
            => Connectivity.NetworkAccess == NetworkAccess.Internet 
               && Connectivity.ConnectionProfiles.Contains(ConnectionProfile.Cellular);

        public ConnectionState CurrentConnection => GetState();
         
        private async void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var newConnectionState = GetState();
            if (newConnectionState.Access != _previousNetworkAccess)
            {
                _logger.LogTrace("Network access changed from {OldNetworkAccess} to {NetworkAccess}", _previousNetworkAccess, newConnectionState.Access);
                await UpdateSubscribersAsync(newConnectionState);
                _previousNetworkAccess = newConnectionState.Access;
            }
            
        }

        private ConnectionState GetState()
        {
            var currentState = new ConnectionState(
                (ConnectionAccess) Connectivity.NetworkAccess, 
                Connectivity.ConnectionProfiles.Select(x => (ConnectionType)x));

            _logger.LogTrace("Retrieved current network state: {NetworkAccess}. IsConnected: {IsConnected}", currentState.Access, currentState.IsConnected);

            return currentState;
        }
    }
}