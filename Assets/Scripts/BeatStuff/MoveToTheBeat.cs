using BeatStuff.EventImplementations;
using DirectionImplementation;
using Events;
using UnityEngine;

namespace BeatStuff
{
    public class MoveToTheBeat : MonoBehaviour
    {
        public float Steps = 1f;

        public DirectionName DirectionName;
        public Vector3 MoveDir;
        
        [SerializeField]
        private float m_MoveAmount = 1.15f;

        [SerializeField]
        private float m_SpeedFactor = 10f;
        
        private Vector3 m_MovePos;
        
        public void Initialize()
        {
            m_MovePos = transform.localPosition;
            GEM.AddListener<OnBeatEvent>(OnBeat);
        }

        private void OnBeat(OnBeatEvent evt)
        {
            if (evt.Steps == Steps)
            {
                Move();
            }
        }

        private void Update()
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, m_MovePos, Time.deltaTime * m_SpeedFactor);
        }

        public void Move()
        {
            m_MovePos += MoveDir * m_MoveAmount;
        }

        public void ResetData()
        {
            GEM.RemoveListener<OnBeatEvent>(OnBeat);
        }
    }
}