using System.Collections.Generic;
using SoundManagement;
using Sounds;
using UnityEngine;

namespace LevelManagement
{
    [CreateAssetMenu(fileName = "LevelDataBundle", menuName = "LevelManagement/LevelDataBundle")]
    public class LevelDataBundle : ScriptableObject
    {
        public float LevelIndex;
        
        public Sound MainSound;

        public List<Sound> MainSounds = new List<Sound>();
        
        public SoundBundle SoundBundle;

        public Sound BadSound;
    }
}
