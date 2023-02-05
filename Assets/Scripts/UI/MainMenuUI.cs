using System;
using DG.Tweening;
using Events;
using SceneManagement;
using SettingImplementations;
using Sounds;
using UnityCommon.Modules;
using UnityCommon.Runtime.UI.Animations;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        private bool m_ButtonPressed;

        private Sprite m_NormalSprite;

        [SerializeField] private Sprite m_PressedImage;

        [SerializeField] private Image m_ButtonImage;
        
        [SerializeField] private UIAlphaAnim m_UIAlphaAnim;

       // [SerializeField] private Light2D m_Light2D;


        private void Awake()
        {
            m_NormalSprite = m_ButtonImage.sprite;
            m_ButtonPressed = false;
            
            m_UIAlphaAnim.FadeIn();
            
            //DOTween.To(value => m_Light2D.intensity = value, 4, 8.5f, 5f).SetEase(Ease.InElastic).SetLoops(-1);
        }

        public void LoadGame()
        {
            if(m_ButtonPressed)
                return;
            
            m_ButtonPressed = true;
            
            m_ButtonImage.sprite = m_PressedImage;
            
            using var evt2 = SoundPlayEvent.Get(GeneralSettings.Get().m_UISelect);
            evt2.SendGlobal();
            
            m_UIAlphaAnim.FadeOut();

            Conditional.Wait(0.5f).Do(() =>
            {
                using var evt2 = SoundPlayEvent.Get(GeneralSettings.Get().m_StartSound);
                evt2.SendGlobal();
                
                using var evt = SceneChangeRequestEvent.Get(SceneId.Game);
                evt.SendGlobal();
                
                m_ButtonImage.sprite = m_NormalSprite;

                m_ButtonPressed = false;
            });
        }
    }
}
