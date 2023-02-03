using System.Collections.Generic;
using DirectionImplementation;
using Events;
using PlayerImplementations.EventImplementations;
using UnityEngine;

namespace PlayerImplementations
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] 
        private PlayerData m_PlayerData;
        
        private DirectionName m_CurrentDirection;

        private Dictionary<DirectionName, float> m_RotOnDir = new Dictionary<DirectionName, float>()
        {
            [DirectionName.S] = 0,
            [DirectionName.D] = 90,
            [DirectionName.W] = 180,
            [DirectionName.A] = 270,
            [DirectionName.WA] = 225,
            [DirectionName.WD] = 135,
            [DirectionName.SA] = 315,
            [DirectionName.SD] = 45
        };

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                m_CurrentDirection = DirectionName.S;
                Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                m_CurrentDirection = DirectionName.D;
                Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                m_CurrentDirection = DirectionName.W;
                Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                m_CurrentDirection = DirectionName.A;
                Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                m_CurrentDirection = DirectionName.SA;
                Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                m_CurrentDirection = DirectionName.SD;
                Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                m_CurrentDirection = DirectionName.WA;
                Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                m_CurrentDirection = DirectionName.WD;
                Attack(m_CurrentDirection);
            }
        }

        private void Attack(DirectionName directionName)
        {
            transform.rotation = Quaternion.Euler(0, 0, m_RotOnDir[m_CurrentDirection]);
            using var evt = AttackEvent.Get(directionName, true);
            evt.SendGlobal();
        }
    }
}