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
        
        public Sound GetSound(DirectionName directionName)
        {
            switch (directionName)
            {
                case DirectionName.W:
                    return m_W;
                    break;
                case DirectionName.A:
                    return m_A;
                    break;
                case DirectionName.S:
                    return m_S;
                    break;
                case DirectionName.D:
                    return m_D;
                    break;
                case DirectionName.WA:
                    return m_WA;
                    break;
                case DirectionName.WD:
                    return m_WD;
                    break;
                case DirectionName.SA:
                    return m_SA;
                    break;
                case DirectionName.SD:
                    return m_SD;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(directionName), directionName, null);
            }
        }
    }
}
