using UnityEngine;

namespace BeatStuff
{
    public class MoveToTheBeat : MonoBehaviour
    {
        [SerializeField]
        private float m_MoveAmount = 1.15f;

        [SerializeField]
        private float m_SpeedFactor = 5f;
        
        private Vector3 m_MovePos;

        private void Start()
        {
           m_MovePos = transform.localPosition;
        }

        private void Update()
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, m_MovePos, Time.deltaTime * m_SpeedFactor);
        }

        public void Move()
        {
            m_MovePos += Vector3.right * m_MoveAmount;
        }
    }
}