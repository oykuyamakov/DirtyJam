using System;
using Events;
using PlayerImplementations.EventImplementations;
using SceneManagement;
using UnityCommon.Modules;
using UnityCommon.Runtime.UI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LooseUI : MonoBehaviour
    {
        [SerializeField] private UITranslateAnim m_LoosePanelAnim;

        [SerializeField]
        private Canvas m_Canvas;

        [SerializeField]
        private Button m_Button;
        
        private bool m_ButtonPressed;
        
        private void Awake()
        {
            GEM.AddListener<LooseEvent>(OnLooseEvent);
            m_Button.onClick.AddListener(OnButton);
        }

        private void OnDisable()
        {
            GEM.RemoveListener<LooseEvent>(OnLooseEvent);
        }

        private void OnLooseEvent(LooseEvent evt)
        {
            m_Canvas.enabled = true;
            m_LoosePanelAnim.FadeIn();
        }

        private void OnButton()
        {
            if(m_ButtonPressed)
                return;
            
            m_ButtonPressed = true;
            m_LoosePanelAnim.FadeOut();

            using var evt = SceneChangeRequestEvent.Get(SceneId.Game).SendGlobal();
            
            Conditional.Wait(0.25f).Do(() =>
            {
                m_ButtonPressed = false;
                m_Canvas.enabled = false;
            });
        }
        
        
    }
}
