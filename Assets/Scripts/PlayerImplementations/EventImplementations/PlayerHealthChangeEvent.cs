using Events;

namespace PlayerImplementations.EventImplementations
{
    public class PlayerHealthChangeEvent : Event<PlayerHealthChangeEvent>
    {
        public float OldHealth;
        public float NewHealth;
        public static PlayerHealthChangeEvent Get(float oldHealth, float newHealth)
        {
            var evt = GetPooledInternal();
            evt.OldHealth = oldHealth;
            evt.NewHealth = newHealth;
            return evt;
        }
    }
}