using System.Collections.Generic;
using BeatStuff.EventImplementations;
using DirectionImplementation;
using Events;
using PlayerImplementations.EventImplementations;
using SettingImplementations;
using SoundManagement;
using UnityCommon.Modules;
using UnityEngine;

namespace LevelManagement
{
    public class LevelManager : MonoBehaviour
    {
        private LevelDataBundle m_CurrentLevelDataBundle => m_Settings.GetCurrentBundle();
        private GeneralSettings m_Settings => GeneralSettings.Get();
        private SoundBundle m_CurrentSoundBundle => m_CurrentLevelDataBundle.SoundBundle;

        private DirectionName m_QueuedDirection;

        [SerializeField] private List<Animator> m_FireAnimators1;
        [SerializeField] private List<Animator> m_FireAnimators2;
        [SerializeField] private List<Animator> m_FireAnimators3;
        [SerializeField] private List<Animator> m_FireAnimators4;

        private void AnimateFiresArbitrary()
        {
            foreach (var f1 in m_FireAnimators1)
            {
                f1.gameObject.SetActive(true);
                f1.SetTrigger("Fire");
            }
            
            Conditional.Wait(0.2f).Do(() =>
            {
                foreach (var f2 in m_FireAnimators2)
                {
                    f2.gameObject.SetActive(true);
                    f2.SetTrigger("Fire");
                }
                
                Conditional.Wait(0.2f).Do(() =>
                {
                    foreach (var f3 in m_FireAnimators3)
                    {
                        f3.gameObject.SetActive(true);
                        f3.SetTrigger("Fire");
                    }
                    
                    Conditional.Wait(0.2f).Do(() =>
                    {
                        foreach (var f4 in m_FireAnimators4)
                        {
                            f4.gameObject.SetActive(true);
                            f4.SetTrigger("Fire");
                        }
                        
                        Conditional.Wait(0.2f).Do(() =>
                        {
                            foreach (var f1 in m_FireAnimators1)
                            {
                                f1.gameObject.SetActive(false);
                            }
                            
                            Conditional.Wait(0.2f).Do(() =>
                            {
                                foreach (var f2 in m_FireAnimators2)
                                {
                                    f2.gameObject.SetActive(false);
                                }
                                
                                Conditional.Wait(0.2f).Do(() =>
                                {
                                    foreach (var f3 in m_FireAnimators3)
                                    {
                                        f3.gameObject.SetActive(false);
                                    }
                                    
                                    Conditional.Wait(0.2f).Do(() =>
                                    {
                                        foreach (var f4 in m_FireAnimators4)
                                        {
                                            f4.gameObject.SetActive(false);
                                        }
                                    });
                                });
                            });
                        });

                    });
                });
            });
        }
        
        private void Awake()
        {
            GEM.AddListener<AttackEvent>(OnAttackEvent, Priority.Lowest);
            GEM.AddListener<WinEvent>(OnWin);
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
        
        private void OnWin(WinEvent evt)
        {
            AnimateFiresArbitrary();
        }

        private void OnLoose()
        {
            
        }
    }
}
