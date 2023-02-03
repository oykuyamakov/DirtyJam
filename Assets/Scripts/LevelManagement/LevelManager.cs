using Events;
using PlayerImplementations.EventImplementations;
using SettingImplementations;
using SoundManagement;
using UnityEngine;

namespace LevelManagement
{
    public class LevelManager : MonoBehaviour
    {
        private LevelDataBundle m_CurrentLevelDataBundle => m_Settings.GetCurrentBundle();
        private GeneralSettings m_Settings => GeneralSettings.Get();
        private SoundBundle m_CurrentSoundBundle => m_CurrentLevelDataBundle.SoundBundle;

        private void Awake()
        {
            GEM.AddListener<AttackEvent>(OnAttackEvent,Priority.Lowest);
        }

        private void OnAttackEvent(AttackEvent evt)
        {
            if (evt.Success)
            {
                using var evtSound = SoundPlayEvent.Get(m_CurrentSoundBundle.GetSound(evt.AttackDirection));
                evtSound.SendGlobal();
                Debug.Log("aaaa");
            }
            else
            {
                using var evtSound = SoundPlayEvent.Get(m_CurrentLevelDataBundle.BadSound);
                evtSound.SendGlobal();
            }
        }
    }
}
