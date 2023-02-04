using System;
using UnityEngine;

namespace CameraEffect
{
    public class CameraController : MonoBehaviour
    {

        private float m_ShakeDurationRemaining;

        public void LateUpdate()
        {
            if (m_ShakeDurationRemaining > 0)
            {
                m_ShakeDurationRemaining -= Time.deltaTime;
                
                // float xAmount = 
                // float yAmount
                //
                transform.localPosition = UnityEngine.Random.insideUnitSphere * 0.1f;
            }
            else
            {
                transform.localPosition = Vector3.zero;
            }
        }
    }
}
