using Blauhaus.Analytics.Abstractions;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.Common.Utils.Disposables;
using Blauhaus.DeviceServices.Abstractions.Connectivity;
using Blauhaus.DeviceServices.Abstractions.Thread;
using Microsoft.Extensions.Logging;

namespace Blauhaus.DeviceServices.Maui
{
    public class ConnectivityService : BasePublisher, IConnectivityService
    {
        private readonly IAnalyticsLogger<ConnectivityService> _logger;
        private readonly IThreadService _threadService;
        private ConnectionAccess _previousNetworkAccess = ConnectionAccess.Unknown;
        
        private IConnectivity _mauiConnectivity 
            => Connectivity.Current;

        public ConnectivityService(
            IAnalyticsLogger<ConnectivityService> logger,
            IThreadService threadService)
        {
            _logger = logger;
            _threadService = threadService;

            Connectivity.ConnectivityChanged += HandleConnectivityChanged;
        }

        public Task<IDisposable> SubscribeAsync(Func<ConnectionState, Task> handler, Func<ConnectionState, bool>? filter = null)
        {
            return Task.FromResult(AddSubscriber(handler, filter));
        }
       
        public bool IsConnectedToInternet 
            => _mauiConnectivity.NetworkAccess == NetworkAccess.Internet;
        
           
        public bool IsConnectionUsingCellularData 
            => _mauiConnectivity.NetworkAccess == NetworkAccess.Internet 
               && _mauiConnectivity.ConnectionProfiles.Contains(ConnectionProfile.Cellular);

        public ConnectionState CurrentConnection => GetState();
         
        private async void HandleConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
        {
            var newConnectionState = GetState();
            if (newConnectionState.Access != _previousNetworkAccess)
            {
                _logger.LogTrace("Network access changed from {OldNetworkAccess} to {NetworkAccess}", _previousNetworkAccess, newConnectionState.Access);
                await UpdateSubscribersAsync(newConnectionState);
                _previousNetworkAccess = newConnectionState.Access;
            }
            
        }
        public async Task<ConnectionState> GetConnectionStateAsync()
        {
            return await _threadService.InvokeOnMainThreadAsync(() =>
            {
                var currentState = new ConnectionState(
                    (ConnectionAccess)_mauiConnectivity.NetworkAccess,
                    _mauiConnectivity.ConnectionProfiles.Select(x => (ConnectionType)x));

                _logger.LogTrace("Retrieved current network state: {NetworkAccess}. IsConnected: {IsConnected}", currentState.Access, currentState.IsConnected);

                return currentState;
            });
        }

        private ConnectionState GetState()
        {
            var currentState = new ConnectionState(
                (ConnectionAccess) _mauiConnectivity.NetworkAccess, 
                _mauiConnectivity.ConnectionProfiles.Select(x => (ConnectionType)x));

            _logger.LogTrace("Retrieved current network state: {NetworkAccess}. IsConnected: {IsConnected}", currentState.Access, currentState.IsConnected);

            return currentState;
        }
    }
}