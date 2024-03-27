using Blauhaus.DeviceServices.Abstractions.Haptics;

namespace Blauhaus.DeviceServices.Maui;

public class HapticFeedbackService : IHapticFeedbackService
{
    public void Vibrate(TimeSpan duration)
    {
        Vibration.Vibrate(duration);
    }
}