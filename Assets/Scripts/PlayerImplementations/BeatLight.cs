using BeatStuff.EventImplementations;
using DG.Tweening;
using Events;
using PlayerImplementations.EventImplementations;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace PlayerImplementations
{
    public class BeatLight : MonoBehaviour
    {
        [SerializeField] 
        private Light2D m_Light2D;
        
        private Tween m_Tween;
        
        private void Awake()
        {
            GEM.AddListener<OnBeatEvent>(OnBeatEvent, Priority.Lowest);
        }

        private void OnBeatEvent(OnBeatEvent evt)
        {
            m_Tween = DOTween.To(value => m_Light2D.intensity = value, 1f, 1.5f, 0.12f);
            m_Tween.onComplete = () =>
            {
                DOTween.To(value => m_Light2D.intensity = value, 1.5f, 1f, 0.05f); };
        }
    }
}
