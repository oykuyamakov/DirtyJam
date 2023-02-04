using Events;
using Sounds;
using UnityEngine;
using Utility;

namespace PlayerImplementations
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        public float MaxHealth;
        
        public FloatState CurrentHealth;
        
        public string Name;

        public Sound GetHitSound;

        public void Initialize()
        {
            CurrentHealth = new FloatState(MaxHealth,
                new SpecialCondition<float>(0, OnDie, ComparisionMethod.LesserOrEqualOnce));
        }

        public void OnDie()
        {
            
        }
        
        public void OnGetDamage(float damage)
        {
            CurrentHealth.Change(-damage);
            using var evt = SoundPlayEvent.Get(GetHitSound);
            evt.SendGlobal();
        }
    }
}
