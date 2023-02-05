using System;
using System.Collections.Generic;
using DG.Tweening;
using Events;
using PlayerImplementations.EventImplementations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_HealthText;
        
        [SerializeField]
        private List<Image> m_HealthImages = new List<Image>();

        private int Index;

        private void OnGetDamage()
        {
            if(Index > m_HealthImages.Count - 1)
                return;
            
            m_HealthImages[Index].DOFade(0, 0.2f);
            Index++;
        }

        private void Awake()
        {
            GEM.AddListener<PlayerHealthChangeEvent>(OnHealthChangeEvent);
        }

        private void OnDisable()
        {
            GEM.RemoveListener<PlayerHealthChangeEvent>(OnHealthChangeEvent);    
        }

        public void OnHealthChangeEvent(PlayerHealthChangeEvent evt)
        {
            OnGetDamage();
           // SetHealth((int)evt.NewHealth);
        }
        public void SetHealth(int health)
        {
            m_HealthText.text = health.ToString();
        }
    }
}
