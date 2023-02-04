using System;
using System.Collections.Generic;
using DirectionImplementation;
using Sounds;
using UnityEngine;

namespace SoundManagement
{
    [CreateAssetMenu (fileName = "SoundBundle", menuName = "SoundManagement/SoundBundle")]
    public class SoundBundle : ScriptableObject
    {
        public Sound m_W;
        public Sound m_A;
        public Sound m_S;
        public Sound m_D;
        public Sound m_WA;
        public Sound m_WD;
        public Sound m_SA;
        public Sound m_SD;

        private Dictionary<DirectionName, Sound> m_SoundsOnDir = new Dictionary<DirectionName, Sound>();
        
        public Sound GetSound(DirectionName directionName)
        {
            if (m_SoundsOnDir.TryGetValue(directionName, out var sound))
            {
                return sound;
            }
            else
            {
                m_SoundsOnDir = new Dictionary<DirectionName, Sound>()
                {
                    [DirectionName.S] = m_S,
                    [DirectionName.D] = m_D,
                    [DirectionName.W] = m_W,
                    [DirectionName.A] = m_A,
                    [DirectionName.W & DirectionName.A] = m_WA,
                    [DirectionName.W & DirectionName.D] = m_WD,
                    [DirectionName.S & DirectionName.A] = m_SA,
                    [DirectionName.S & DirectionName.D] = m_SD
                };

                return m_SoundsOnDir[directionName];
            }
        }
        
        private void Awake()
        {
            m_SoundsOnDir = new Dictionary<DirectionName, Sound>()
            {
                [DirectionName.S] = m_S,
                [DirectionName.D] = m_D,
                [DirectionName.W] = m_W,
                [DirectionName.A] = m_A,
                [DirectionName.W & DirectionName.A] = m_WA,
                [DirectionName.W & DirectionName.D] = m_WD,
                [DirectionName.S & DirectionName.A] = m_SA,
                [DirectionName.S & DirectionName.D] = m_SD
            };
        }
    }
}
