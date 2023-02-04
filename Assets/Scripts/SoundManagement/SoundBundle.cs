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

        private Dictionary<DirectionName, Sound[]> m_SoundsOnDir = new();
        
        public Sound[] GetSound(DirectionName directionName)
        {
            if (m_SoundsOnDir.TryGetValue(directionName, out var sound))
            {
                return sound;
            }
            else
            {
                m_SoundsOnDir = new Dictionary<DirectionName, Sound[]>()
                {
                    [DirectionName.S] = new[] { m_S },
                    [DirectionName.D] = new[] { m_D },
                    [DirectionName.W] = new[] { m_W },
                    [DirectionName.A] = new[] { m_A },
                    [DirectionName.W | DirectionName.A] = new[] { m_W, m_A },
                    [DirectionName.W | DirectionName.D] = new[] { m_W, m_D },
                    [DirectionName.S | DirectionName.A] = new[] { m_S, m_A },
                    [DirectionName.S | DirectionName.D] = new[] { m_S, m_D }
                };

                return m_SoundsOnDir[directionName];
            }
        }
    }
}
