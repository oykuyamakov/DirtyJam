using Events;

namespace BeatStuff.EventImplementations
{
    public class OnBeatEvent : Event<OnBeatEvent>
    {
        public float Steps;
        
        public static OnBeatEvent Get(float steps)
        {
            var evt = GetPooledInternal();
            evt.Steps = steps;
            return evt;
        }
    }
}