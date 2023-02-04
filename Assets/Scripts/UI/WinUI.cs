using Events;
using PlayerImplementations.EventImplementations;
using UnityCommon.Modules;
using UnityCommon.Runtime.UI.Animations;
using UnityEngine;

namespace UI
{
    public class WinUI : MonoBehaviour
    {
        [SerializeField] private UITranslateAnim m_WinPanelAnim;
        
        private bool m_ButtonPressed;
        private void Awake()
        {
            GEM.AddListener<WinEvent>(OnWinEvent);
        }
        
        private void OnDisable()
        {
            GEM.RemoveListener<WinEvent>(OnWinEvent);
        }
        
        private void OnWinEvent(WinEvent evt)
        {
            m_WinPanelAnim.FadeIn();
        }
        
        private void OnButton()
        {
            if(m_ButtonPressed)
                return;
            m_ButtonPressed = true;
            m_WinPanelAnim.FadeOut();
        
            Conditional.Wait(1f).Do(() =>
            {
                m_ButtonPressed = true;
            });
        }
    }
}
