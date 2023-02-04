using System;
using UnityEngine;

namespace GridStuff
{
    public class ActivateIfTouched : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_BgSprite;
        
        [SerializeField]
        private Collider2D m_Collider;

        private void OnTriggerEnter2D(Collider2D other)
        {
            m_BgSprite.SetActive(true);
        }
    }
}