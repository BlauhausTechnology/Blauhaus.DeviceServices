﻿namespace Blauhaus.DeviceServices.Abstractions.Application
{
    public interface IApplicationInfoService
    {
        string CurrentVersion { get; }
        Platform Platform { get; }
    }
}