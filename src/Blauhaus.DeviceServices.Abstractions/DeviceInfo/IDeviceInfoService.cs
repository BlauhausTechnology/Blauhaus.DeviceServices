﻿using System;
using System.Globalization;
using System.Threading.Tasks;
using Blauhaus.Common.ValueObjects.DeviceType;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.DeviceServices.Abstractions.DeviceInfo
{
    public interface IDeviceInfoService
    {
        IDeviceType Type { get; }
        IRuntimePlatform Platform { get; }
        string OperatingSystemVersion { get; }
        string Manufacturer { get; }
        string Model { get; }
        string AppDataFolder { get; }
        CultureInfo CurrentCulture { get; }
        
        [Obsolete("Prefer GetDeviceIdentifierAsync")]
        string DeviceUniqueIdentifier { get; }
        ValueTask<string> GetDeviceIdentifierAsync();
    }
}