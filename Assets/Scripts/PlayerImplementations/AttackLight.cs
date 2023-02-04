using System;
using DG.Tweening;
using Events;
using PlayerImplementations.EventImplementations;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace PlayerImplementations
{
    public class AttackLight : MonoBehaviour
    {
        [SerializeField] 
        private Light2D m_Light2D;


        private Tween m_Tween;
        
        private void Awake()
        {
            GEM.AddListener<AttackEvent>(OnAttackEvent, Priority.Lowest);
        }

        private void OnAttackEvent(AttackEvent evt)
        {
            if (evt.Success)
            {
                m_Tween?.Kill();
                m_Tween = DOTween.To(value => m_Light2D.intensity = value, 0, 11, 0.2f);
                m_Tween.onComplete = () =>
                {
                    m_Light2D.intensity = 0;
                };
            }
        }
    }
}
