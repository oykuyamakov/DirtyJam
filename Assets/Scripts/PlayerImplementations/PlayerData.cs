using Events;
using Sounds;
using UnityCommon.Variables;
using UnityEngine;
using Utility;

namespace PlayerImplementations
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField]
        private FloatVariable m_PlayerHealth;
        
        public float MaxHealth;
        
        public FloatState CurrentHealth;
        
        public string Name;

        public Sound GetHitSound;

        public void Initialize()
        {
            CurrentHealth = new FloatState(MaxHealth,
                new SpecialCondition<float>(0, OnDie, ComparisionMethod.LesserOrEqualOnce),
                () => m_PlayerHealth.Value = CurrentHealth.CurrentValue);
        }

        public void OnDie()
        {
            using var looseEvent = EventImplementations.LooseEvent.Get();
            looseEvent.SendGlobal();
        }
        
        public void OnGetDamage(float damage)
        {
            CurrentHealth.Change(-damage);
            using var evt = SoundPlayEvent.Get(GetHitSound);
            evt.SendGlobal();
        }
    }
}
