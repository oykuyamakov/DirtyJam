using System;
using System.Collections.Generic;
using DirectionImplementation;
using Events;
using PlayerImplementations.EventImplementations;
using UnityCommon.Runtime.Utility;
using UnityEngine;

namespace PlayerImplementations
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] 
        private PlayerData m_PlayerData;
        private Animator m_Animator => GetComponent<Animator>();
        
        private DirectionName m_CurrentDirection;
        
        private static readonly int Attack1 = Animator.StringToHash("Attack");

        private TimedAction m_GetInputAction;
        
        private Dictionary<DirectionName, float> m_RotOnDir = new()
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
        
        private void Awake()
        {
            m_GetInputAction = new TimedAction(GetInput, 0, 0.082f);
            
            m_PlayerData.Initialize();
        }

        private bool Attacked;

        private void GetInput()
        {
            
            if (Attacked)
            {
                Attack(m_CurrentDirection);
                Debug.Log("attacked");
                Attacked = false;
            }
        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.S))
            {
                m_CurrentDirection &= ~DirectionName.S;
            } 
            if (Input.GetKeyUp(KeyCode.W))
            {
                m_CurrentDirection &= ~DirectionName.W;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                m_CurrentDirection &= ~DirectionName.D;
            } 
            if (Input.GetKeyUp(KeyCode.A))
            {
                m_CurrentDirection &= ~DirectionName.A;
            }


            if (Input.GetKeyDown(KeyCode.S))
            {
                m_CurrentDirection |= DirectionName.S;
                Attacked = true;
                //Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                m_CurrentDirection |= DirectionName.D;
                Attacked = true;

                //Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                m_CurrentDirection |= DirectionName.W;
                Attacked = true;

                //Attack(m_CurrentDirection);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                m_CurrentDirection |= DirectionName.A;
                Attacked = true;

                //Attack(m_CurrentDirection);
            }

            
            
            m_GetInputAction.Update(Time.deltaTime);
        }

        private void Attack(DirectionName directionName)
        {
            if (m_CurrentDirection == 0)
                return;
            
            if ((m_CurrentDirection & (DirectionName.D | DirectionName.A)) 
                == (DirectionName.D | DirectionName.A))
                return;
            
            if ((m_CurrentDirection & (DirectionName.S | DirectionName.W)) 
                == (DirectionName.S | DirectionName.W))
                return;
            
            if ((m_CurrentDirection & (DirectionName.W | DirectionName.A | DirectionName.D)) 
                == (DirectionName.W | DirectionName.A | DirectionName.D))
            {
                m_CurrentDirection = DirectionName.W;
            }
            if ((m_CurrentDirection & (DirectionName.S | DirectionName.A | DirectionName.D)) 
                == (DirectionName.S | DirectionName.A | DirectionName.D))
            {
                m_CurrentDirection = DirectionName.S;
            }
            
            Debug.Log("Attacked with direction: " + m_CurrentDirection + "");
            
            m_Animator.SetTrigger(Attack1);
            
            transform.rotation = Quaternion.Euler(0, 0, m_RotOnDir[m_CurrentDirection]);
            var evt = AttackEvent.Get(directionName);
            evt.SendGlobal();
        }
    }
}