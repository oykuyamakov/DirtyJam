using System;
using BeatStuff;
using DirectionImplementation;
using Events;
using PlayerImplementations.EventImplementations;
using UnityEngine;

namespace GridStuff
{
    public class GridSectionBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Collider2D m_Collider;

        [SerializeField]
        private SpriteRenderer m_SpriteRenderer;

        private bool m_Entered;
        private DirectionName m_EnteredDirectionName;
        private GameObject m_EnteredObject;

        private void OnValidate()
        {
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
            m_Collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            m_SpriteRenderer.color = Color.yellow;

            m_Entered = true;
            m_EnteredDirectionName = other.GetComponent<MoveToTheBeat>().DirectionName;
            m_EnteredObject = other.gameObject;
            
            GEM.AddListener<AttackEvent>(OnAttackEvent);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            m_Entered = false;
            m_EnteredObject = null;
            
            GEM.RemoveListener<AttackEvent>(OnAttackEvent);
        }
        
        private void OnAttackEvent(AttackEvent evt)
        {
            if ((evt.AttackDirection & m_EnteredDirectionName) == m_EnteredDirectionName)
            {
                evt.Success = true;
                
                m_EnteredObject.SetActive(false);
            }
        }
    }
}