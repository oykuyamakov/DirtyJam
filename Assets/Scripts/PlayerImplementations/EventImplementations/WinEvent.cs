using Events;

namespace PlayerImplementations.EventImplementations
{
    public class WinEvent : Event<WinEvent>
    {
        public static WinEvent Get()
        {
            var evt = GetPooledInternal();
            return evt;
        }
    }
}