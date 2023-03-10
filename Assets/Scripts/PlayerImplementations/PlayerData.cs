using Events;
using PlayerImplementations.EventImplementations;
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

        public void GetDamage(float damage)
        {
            var oldValue = CurrentHealth.CurrentValue;
            var newVal = CurrentHealth.CurrentValue  - Mathf.Abs(damage);
            CurrentHealth.Change(newVal);
            using var evt = SoundPlayEvent.Get(GetHitSound);
            evt.SendGlobal();
            
            using var evtChange = EventImplementations.PlayerHealthChangeEvent.Get(oldValue, CurrentHealth.CurrentValue);
            evtChange.SendGlobal();

            if (CurrentHealth.CurrentValue <= 0)
            {
                OnDie();
            }
        }

        public void OnHeal(float heal)
        {
            var oldValue = CurrentHealth.CurrentValue;
            var newVal = CurrentHealth.CurrentValue  + Mathf.Abs(heal);
            CurrentHealth.Change(newVal);
            using var evt = SoundPlayEvent.Get(GetHitSound);
            evt.SendGlobal();
            
            using var evtChange = EventImplementations.PlayerHealthChangeEvent.Get(oldValue, CurrentHealth.CurrentValue);
            evtChange.SendGlobal();
        }
    }
}
