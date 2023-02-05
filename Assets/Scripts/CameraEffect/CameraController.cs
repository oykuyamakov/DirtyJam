using System;
using Events;
using PlayerImplementations.EventImplementations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CameraEffect
{
    public class CameraController : MonoBehaviour
    {

        private float m_ShakeDurationRemaining;
        private float m_ShakePower;
        private float m_ShakeFadeTime;
        private float m_ShakeRotation;
        private float m_RotationMultiplier;

        private void Awake()
        {
            GEM.AddListener<AttackEvent>(OnAttackEvent, Priority.Lowest);
        }

        private void OnAttackEvent(AttackEvent evt)
        {
            if (evt.Success)
            {
                StartShake(0.2f, 0.05f);
            }
        }

        public void LateUpdate()
        {
            if (m_ShakeDurationRemaining > 0)
            {
                m_ShakeDurationRemaining -= Time.deltaTime;

                float xAmount = Random.Range(-1, 1) * m_ShakePower;
                float yAmount = Random.Range(-1, 1) * m_ShakePower;
                
                transform.position = new Vector3(xAmount, yAmount, transform.position.z);

                m_ShakePower = Mathf.MoveTowards(m_ShakePower, 0f, m_ShakeFadeTime * Time.deltaTime);

                m_ShakeRotation = Mathf.MoveTowards(m_ShakeRotation, 0f,
                    m_ShakeFadeTime * m_RotationMultiplier * Time.deltaTime);
            }
            
            transform.rotation = Quaternion.Euler(0f,0f,m_ShakeRotation * Random.Range(-1f,1f));
        }

        private void StartShake(float length, float power)
        {
            m_ShakeDurationRemaining = length;
            m_ShakePower = power;

            m_ShakeFadeTime = power / length;
            m_ShakeRotation = power * m_RotationMultiplier;
        }
    }
}
