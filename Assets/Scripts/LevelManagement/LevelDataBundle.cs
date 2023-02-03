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
        
        public SoundBundle SoundBundle;

        public Sound BadSound;
    }
}
