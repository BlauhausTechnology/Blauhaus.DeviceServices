using System.Collections.Generic;

namespace Blauhaus.DeviceServices.Abstractions.Connectivity
{
    public readonly struct ConnectionState
    {
        public ConnectionState(ConnectionAccess access, IEnumerable<ConnectionType> types)
        {
            Access = access;
            Types = types;
        }

        public ConnectionState(ConnectionAccess access, params ConnectionType[] types)
        {
            Access = access;
            Types = types;
        }

        public IEnumerable<ConnectionType> Types { get; }
        public ConnectionAccess Access {get;}
    }
}