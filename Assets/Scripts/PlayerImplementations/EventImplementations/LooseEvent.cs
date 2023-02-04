using Events;

namespace PlayerImplementations.EventImplementations
{
    public class LooseEvent : Event<LooseEvent>
    {
        public static LooseEvent Get()
        {
            var evt = GetPooledInternal();
            return evt;
        }
    }
}