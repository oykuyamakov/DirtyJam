using System;
using UnityEngine;

namespace BeatStuff
{
    public class PulseToTheBeat : MonoBehaviour
    {
        [SerializeField]
        private float m_PulseSize = 1.15f;

        [SerializeField]
        private float m_ReturnSpeed = 5f;

        private Vector3 m_StartSize;

        private void Start()
        {
            m_StartSize = transform.localScale;
        }

        private void Update()
        {
            transform.localScale = Vector3.Lerp(transform.localScale, m_StartSize, Time.deltaTime * m_ReturnSpeed);
        }

        public void Pulse()
        {
            transform.localScale = m_StartSize * m_PulseSize;
        }
    }
}