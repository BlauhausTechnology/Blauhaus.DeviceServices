using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.DeviceServices.Abstractions.Connectivity
{
    public class ConnectionState : BaseValueObject<ConnectionState>
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

        public bool IsConnected => Access == ConnectionAccess.Internet;

        public static ConnectionState Disconnected = new ConnectionState(ConnectionAccess.None, new List<ConnectionType>());
        public static ConnectionState Wifi = new ConnectionState(ConnectionAccess.Internet, ConnectionType.WiFi);
        public static ConnectionState Cellular = new ConnectionState(ConnectionAccess.Internet, ConnectionType.Cellular);


        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append("Current: ").Append(Access.ToString());

            if (Types.Any())
            {
                s.Append(" Types: | ");
                foreach (var connectionType in Types)
                {
                    s.Append(connectionType.ToString()).Append(" | ");
                }
            }

            return s.ToString();
        }

        protected override int GetHashCodeCore()
        {
            return Access.GetHashCode();
        }

        protected override bool EqualsCore(ConnectionState other)
        {
            return other.Access == Access;
        }
    }
}