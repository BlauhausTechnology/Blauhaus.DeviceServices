using System;
using Blauhaus.DeviceServices.Abstractions.Haptics;

namespace Blauhaus.DeviceServices.Common.Haptics;

public class HapticFeebackService : IHapticFeedbackService
{
    public void Vibrate(TimeSpan duration)
    {
        Xamarin.Essentials.Vibration.Vibrate(duration);
    }
}