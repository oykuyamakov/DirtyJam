using System;
using System.Collections.Generic;
using SceneManagement;
using Sounds;
using UnityCommon.Runtime.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace SettingImplementations
{
    [CreateAssetMenu(fileName =" GeneralSettings" )]
    public class GeneralSettings : ScriptableObject
    {
        private static GeneralSettings _GeneralSettings;

        private static GeneralSettings generalSettings
        {
            get
            {
                if (!_GeneralSettings)
                {
                    _GeneralSettings = Resources.Load<GeneralSettings>($"Settings/GeneralSettings");

                    if (!_GeneralSettings)
                    {
#if UNITY_EDITOR
                        Debug.Log("General Settings");
                        // _BossOnesettings = CreateInstance<GeneralSettings>();
                        // var path = "Assets/Resources/Settings/GeneralSettings.asset";
                        // AssetDatabaseHelpers.CreateAssetMkdir(_GeneralSettings, path);
#else
 				//		throw new Exception("Global settings could not be loaded");
#endif
                    }
                }

                return _GeneralSettings;
            }
        }
        
        public static GeneralSettings Get()
        {
            return generalSettings;
        }

        //public string InitialSaveName;

        public float SceneTransitionDuration = 2f;
        
        public float IntroWaitDuration = 2f;

        public float MinuteToRealTime = 0.7f;

        public float LoadingFadeInDuration = 0.8f;
        public float LoadingFadeOutDuration = 0.8f;

        // TODO: HATE THE NAMES
        public int DayHour = 10;
        
        public int NightHour = 20;

        [FormerlySerializedAs("m_ComicsBySceneIds")] [SerializeField]
        public SerializableDictionary<SceneId, List<Sprite>> ComicsBySceneIds;
        [FormerlySerializedAs("m_ScreensOnTransitions")] [SerializeField]
        public SerializableDictionary<SceneToScene, List<Sprite>> ScreensOnTransitions;
        
        [Header("COMBAT")]
        public float ScreenShakeDuration = 0.2f;
        public float ScreenShakeMagnitude = 5f;
        
        [SerializeField]
        public SerializableDictionary<SceneId, Sound> MusicsOnScenes = new SerializableDictionary<SceneId, Sound>();
        
        // [SerializeField] 
        // public Sound MenuSound;
        // [SerializeField] 
        // public Sound HubSound;
        // [SerializeField]
        // public Sound BossSound;
    }

    [Serializable]
    public struct SceneToScene
    {
        public SceneId From;
        public SceneId To;
    }
}
