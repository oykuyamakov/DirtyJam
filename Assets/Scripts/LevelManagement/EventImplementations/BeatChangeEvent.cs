using Events;
using UnityEngine;

namespace LevelManagement.EventImplementations
{
    public class BeatChangeEvent : Event<BeatChangeEvent>
    {
        public int index;
        public static BeatChangeEvent Get(int index)
        {
            var evt = GetPooledInternal();
            evt.index = index;
            return evt;
        }
    }
}
