using Events;
using PlayerImplementations.EventImplementations;
using SceneManagement;
using UnityCommon.Modules;
using UnityCommon.Runtime.UI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinUI : MonoBehaviour
    {
        [SerializeField] private UITranslateAnim m_WinPanelAnim;
        
        [SerializeField]
        private Canvas m_Canvas;

        [SerializeField]
        private Button m_Button;
        
        private bool m_ButtonPressed;
        
        private void Awake()
        {
            GEM.AddListener<WinEvent>(OnWinEvent);
            m_Button.onClick.AddListener(OnButton);
        }
        
        private void OnDisable()
        {
            GEM.RemoveListener<WinEvent>(OnWinEvent);
            m_Button.onClick.RemoveListener(OnButton);
        }
        
        private void OnWinEvent(WinEvent evt)
        {
            m_Canvas.enabled = true;
            m_WinPanelAnim.FadeIn();
        }
        
        private void OnButton()
        {
            if(m_ButtonPressed)
                return;
            
            m_ButtonPressed = true;
            m_WinPanelAnim.FadeOut();

            using var evt = SceneChangeRequestEvent.Get(SceneId.Game).SendGlobal();
            
            Conditional.Wait(0.25f).Do(() =>
            {
                m_ButtonPressed = false;
                m_Canvas.enabled = false;
            });
        }
    }
}
