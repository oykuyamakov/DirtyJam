using BeatStuff.EventImplementations;
using DirectionImplementation;
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

        private DirectionName m_QueuedDirection;
        
        private void Awake()
        {
            GEM.AddListener<AttackEvent>(OnAttackEvent, Priority.Lowest);
        }

        private void OnAttackEvent(AttackEvent evt)
        {
            if (evt.Success)
            {
                // m_QueuedDirection = evt.AttackDirection;
                //
                // GEM.AddListener<OnBeatEvent>(OnBeat);
                
                var sounds = m_CurrentSoundBundle.GetSound(evt.AttackDirection);

                foreach (var sound in sounds)
                {
                    using var evtSound = SoundPlayEvent.Get(sound);
                    evtSound.SendGlobal();
                }
            }
            else
            {
                using var evtSound = SoundPlayEvent.Get(m_CurrentLevelDataBundle.BadSound);
                evtSound.SendGlobal();
            }
            
            evt.Dispose();
        }

        private void OnBeat(OnBeatEvent evt)
        {
            var sounds = m_CurrentSoundBundle.GetSound(m_QueuedDirection);

            foreach (var sound in sounds)
            {
                using var evtSound = SoundPlayEvent.Get(sound);
                evtSound.SendGlobal();
            }

            GEM.RemoveListener<OnBeatEvent>(OnBeat);
        }
        
        private void OnWin()
        {
            
        }

        private void OnLoose()
        {
            
        }
    }
}
