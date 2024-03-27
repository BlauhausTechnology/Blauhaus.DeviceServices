using System;

namespace Blauhaus.DeviceServices.Abstractions.Haptics;

public interface IHapticFeedbackService 
{
    void Vibrate(TimeSpan  duration);
}