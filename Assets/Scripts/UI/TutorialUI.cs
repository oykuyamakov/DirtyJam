using System;
using System.Collections.Generic;
using Events;
using LevelManagement.EventImplementations;
using UnityCommon.Modules;
using UnityCommon.Runtime.UI.Animations;
using UnityEngine;

namespace UI
{
    public class TutorialUI : MonoBehaviour
    {
        [SerializeField] private List<UITranslateAnim> m_MainWays;
        [SerializeField] private List<UITranslateAnim> m_ComboWays;

        private int m_Index;

        private void Awake()
        {
            foreach (var ma in m_MainWays)
            {
                ma.FadeOut();
            }
        
            foreach (var ma in m_ComboWays)
            {
                ma.FadeOut();
            }
            
            GEM.AddListener<BeatChangeEvent>(OnBeatChangeEvent);
        }


        public void OnBeatChangeEvent(BeatChangeEvent evt)
        {
            Debug.Log(evt.index);
            m_Index = evt.index;
            Conditional.Wait(1f).Do(() =>
            {
                if (m_Index == 0)
                {
                    for (int i = 0; i < m_MainWays.Count; i++)
                    {
                        m_MainWays[i].GetComponent<UITranslateAnim>().FadeIn();
                    }
                }
                else
                {
                    for (int i = 0; i < m_ComboWays.Count; i++)
                    {
                        m_ComboWays[i].GetComponent<UITranslateAnim>().FadeIn();
                    }
                }

                Conditional.Wait(6f).Do(TurnOff);
            });
           
        }

        private void TurnOff()
        {
            
            Debug.Log("anani");

            if (m_Index == 0)
            {
                foreach (var ma in m_MainWays)
                {
                    ma.FadeOut();
                }
            }
            else
            {
                foreach (var ma in m_ComboWays)
                {
                    ma.FadeOut();
                }
            }
        }
    }
}
