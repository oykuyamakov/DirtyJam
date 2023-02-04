using System;
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

        private void Awake()
        {
            m_PlayerData.Initialize();
        }

        private Dictionary<DirectionName, float> m_RotOnDir = new Dictionary<DirectionName, float>()
        {
            [DirectionName.S] = 0,
            [DirectionName.D] = 90,
            [DirectionName.W] = 180,
            [DirectionName.A] = 270,
            [DirectionName.W | DirectionName.A] = 225,
            [DirectionName.W | DirectionName.D] = 135,
            [DirectionName.S | DirectionName.A] = 315,
            [DirectionName.S | DirectionName.D] = 45,
        };
        
        private void Update()
        {

            if (Input.GetKeyUp(KeyCode.S))
            {
                m_CurrentDirection &= ~DirectionName.S;
                //Attack(m_CurrentDirection);
            } 
            if (Input.GetKeyUp(KeyCode.W))
            {
                m_CurrentDirection &= ~DirectionName.W;
                //Attack(m_CurrentDirection);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                m_CurrentDirection &= ~DirectionName.D;
                //Attack(m_CurrentDirection);
            } 
            if (Input.GetKeyUp(KeyCode.A))
            {
                m_CurrentDirection &= ~DirectionName.A;
                //Attack(m_CurrentDirection);
            }


            if (Input.GetKeyDown(KeyCode.S))
            {
                m_CurrentDirection |= DirectionName.S;
                Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                m_CurrentDirection |= DirectionName.D;
                Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                m_CurrentDirection |= DirectionName.W;
                Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                m_CurrentDirection |= DirectionName.A;
                Attack(m_CurrentDirection);
            }
        }

        private void Attack(DirectionName directionName)
        {
            if (m_CurrentDirection == 0)
            {
                Debug.Log("kalktilann");
                return;
            }

            if ((m_CurrentDirection & (DirectionName.D | DirectionName.A)) == (DirectionName.D | DirectionName.A))
            {
                Debug.Log("D A");
                return;
            }
            if ((m_CurrentDirection & (DirectionName.S | DirectionName.W)) == (DirectionName.S | DirectionName.W))
            {
                Debug.Log("w s");
                return;
            }
            
            if ((m_CurrentDirection & (DirectionName.W | DirectionName.A | DirectionName.D)) == (DirectionName.W | DirectionName.A | DirectionName.D))
            {
                m_CurrentDirection = DirectionName.W;
                Debug.Log("threesome");
            }
            if ((m_CurrentDirection & (DirectionName.S | DirectionName.A | DirectionName.D)) == (DirectionName.S | DirectionName.A | DirectionName.D))
            {
                m_CurrentDirection = DirectionName.S;
                Debug.Log("threesome 2");
            }
            
            transform.rotation = Quaternion.Euler(0, 0, m_RotOnDir[m_CurrentDirection]);
            using var evt = AttackEvent.Get(directionName);
            evt.SendGlobal();
        }
    }
}