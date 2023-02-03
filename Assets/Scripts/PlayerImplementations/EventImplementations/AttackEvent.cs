using DirectionImplementation;
using Events;
using UnityEngine;

namespace PlayerImplementations.EventImplementations
{
    public class AttackEvent : Event<AttackEvent>
    {
        public DirectionName AttackDirection;
        public bool Success;
        public static AttackEvent Get(DirectionName attackDirection, bool success)
        {
            var evt = GetPooledInternal();
            evt.AttackDirection = attackDirection;
            evt.Success = success;
            return evt;
        }
    }
}
