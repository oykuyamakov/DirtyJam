using DirectionImplementation;
using Events;
using UnityEngine;

namespace PlayerImplementations.EventImplementations
{
    public class AttackEvent : Event<AttackEvent>
    {
        public DirectionName AttackDirection;
        public bool Success;
        
        public static AttackEvent Get(DirectionName attackDirection)
        {
            var evt = GetPooledInternal();
            evt.AttackDirection = attackDirection;
            return evt;
        }

        public override void Dispose()
        {
            Success = false;
            
            base.Dispose();
        }
    }
}
