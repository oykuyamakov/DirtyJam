using System;
using BeatStuff.EventImplementations;
using Events;
using UnityEngine;
using UnityEngine.Events;

namespace BeatStuff
{
    public class BeatManager : MonoBehaviour
    {
        [SerializeField]
        private float m_BPM;

        [SerializeField]
        private AudioSource m_AudioSource;

        [SerializeField]
        private Intervals[] m_Intervals;

        void Update()
        {
            foreach (var interval in m_Intervals)
            {
                float sampledTime = m_AudioSource.timeSamples /
                                    (m_AudioSource.clip.frequency * interval.GetIntervalLength(m_BPM));
                interval.CheckForNewInterval(sampledTime);
            }
        }
    }

    [Serializable]
    public class Intervals
    {
        [SerializeField]
        private float m_Steps;

        [SerializeField]
        private UnityEvent m_Trigger;

        private int m_LastInterval;
    
        public float GetIntervalLength(float bpm)
        {
            // 60 because beats per minute -> 60 seconds :D
            return 60f / (bpm * m_Steps);
        }

        public void CheckForNewInterval(float interval)
        {
            if (Mathf.FloorToInt(interval) == m_LastInterval) return;
        
            m_LastInterval = Mathf.FloorToInt(interval);
            m_Trigger.Invoke();

            using var evt = OnBeatEvent.Get(m_Steps).SendGlobal();
        }
    }
}