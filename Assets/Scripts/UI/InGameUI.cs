using System;
using Events;
using PlayerImplementations.EventImplementations;
using TMPro;
using UnityEngine;

namespace UI
{
    public class InGameUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI m_HealthText;

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
            SetHealth((int)evt.NewHealth);
        }
        public void SetHealth(int health)
        {
            m_HealthText.text = health.ToString();
        }
    }
}
