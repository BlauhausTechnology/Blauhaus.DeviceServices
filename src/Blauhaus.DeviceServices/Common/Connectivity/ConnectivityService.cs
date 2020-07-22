using System;
using System.Linq;
using System.Reactive.Linq;
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

        public ConnectionState CurrentConnection => GetState();
        
        public IObservable<ConnectionState> Connect()
        {
            return Observable.Create<ConnectionState>(observer =>
            {
                void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs args)
                {
                    observer.OnNext(GetState());
                }

                var subscription = Observable.FromEventPattern<ConnectivityChangedEventArgs>(
                    ev => Xamarin.Essentials.Connectivity.ConnectivityChanged += HandleConnectivityChanged,
                    ev => Xamarin.Essentials.Connectivity.ConnectivityChanged -= HandleConnectivityChanged)
                        .Subscribe();

                return subscription;
            });
        }

        private static ConnectionState GetState()
        {
            return new ConnectionState(
                (ConnectionAccess) Xamarin.Essentials.Connectivity.NetworkAccess, 
                Xamarin.Essentials.Connectivity.ConnectionProfiles.Select(x => (ConnectionType)x));
        }

    }
}