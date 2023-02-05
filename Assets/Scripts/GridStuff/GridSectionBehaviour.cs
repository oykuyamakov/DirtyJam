using System;
using BeatStuff;
using DG.Tweening;
using DirectionImplementation;
using Events;
using PlayerImplementations.EventImplementations;
using RootStuff;
using UnityCommon.Modules;
using UnityEngine;

namespace GridStuff
{
    public class GridSectionBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Collider2D m_Collider;

        [SerializeField]
        private SpriteRenderer m_SpriteRenderer;
        
        [SerializeField]
        private Animator m_FireAnimator;

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
            // m_SpriteRenderer.color = Color.yellow;

            m_Entered = true;
            m_EnteredDirectionName = other.GetComponentInParent<MoveToTheBeat>().DirectionName;
            m_EnteredObject = other.gameObject;
            
            GEM.AddListener<AttackEvent>(OnAttack, Priority.Critical);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            m_Entered = false;
            m_EnteredObject = null;
            
            GEM.RemoveListener<AttackEvent>(OnAttack);
        }
        
        private void OnAttack(AttackEvent evt)
        {
            if ((evt.AttackDirection | m_EnteredDirectionName) == m_EnteredDirectionName)
            {
                evt.Success = true;
                // m_SpriteRenderer.DOFade(0.5f, 0.2f).SetLoops(3, LoopType.Yoyo)
                //     .OnComplete(() =>
                //     {
                //         m_SpriteRenderer.DOFade(0f, 0.05f);
                //     });
                
                m_FireAnimator.SetTrigger("Fire");
                
                Conditional.WaitFrames(1)
                    .Do(() =>
                    {
                        if(m_EnteredObject == null)
                            return;
                        
                        RootManager.RootPool.ReleasePoolable(m_EnteredObject.GetComponentInParent<Root>());
                    });
            }
        }
    }
}