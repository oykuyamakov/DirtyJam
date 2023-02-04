using System;
using Events;
using PlayerImplementations.EventImplementations;
using UnityCommon.Modules;
using UnityCommon.Runtime.UI.Animations;
using UnityEngine;

namespace UI
{
    public class LooseUI : MonoBehaviour
    {
        [SerializeField] private UITranslateAnim m_LoosePanelAnim;

        private bool m_ButtonPressed;
        private void Awake()
        {
            GEM.AddListener<LooseEvent>(OnLooseEvent);
        }

        private void OnDisable()
        {
            GEM.RemoveListener<LooseEvent>(OnLooseEvent);
        }

        private void OnLooseEvent(LooseEvent evt)
        {
            m_LoosePanelAnim.FadeIn();
        }

        private void OnButton()
        {
            if(m_ButtonPressed)
                return;
            m_ButtonPressed = true;
            m_LoosePanelAnim.FadeOut();

            Conditional.Wait(1f).Do(() =>
            {
                m_ButtonPressed = true;
            });
        }
        
        
    }
}
