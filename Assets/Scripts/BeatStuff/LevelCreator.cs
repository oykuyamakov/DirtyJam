using System.Collections.Generic;
using DirectionImplementation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BeatStuff
{
    public class LevelCreator
    {
        public static List<float> A = new List<float>
        {
            8.1f,
            8.3f,
            9.1f,
            9.3f,
            19.3f,
            20.3f,
            21.3f,
            22.3f,
            24.1f,
            24.3f,
            26.1f,
            26.3f,
            30.1f,
            30.2f,
            31.1f,
            31.2f,
            32.1f,
            32.2f,
            33.1f,
            33.2f,
            34.1f,
            34.3f,
            36.1f,
            36.3f
        };
        
        public static List<float> W = new List<float>
        {
            4.1f,
            4.3f,
            5.1f,
            5.3f,
            15.2f,
            16.2f,
            19.1f,
            21.1f,
            24.1f,
            24.2f,
            25.1f,
            25.2f,
            26.1f,
            26.2f,
            27.1f,
            27.2f,
            34.1f,
            34.2f,
            35.1f,
            35.2f,
            36.1f,
            36.2f,
            37.1f,
            37.2f
        };

        public static List<float> S = new List<float>
        {
            6.1f,
            6.3f,
            7.1f,
            7.3f,
            15.1f,
            15.3f,
            16.1f,
            16.3f,
            17.1f,
            17.3f,
            18.1f,
            18.3f,
            19.2f,
            20.2f,
            21.2f,
            22.2f,
            25.1f,
            25.3f,
            27.1f,
            27.3f,
            30.3f,
            31.3f,
            32.3f,
            35.1f,
            35.3f,
            37.1f,
            37.3f,
        };

        public static List<float> D = new List<float>()
        {
            10.1f,
            10.3f,
            11.1f,
            11.3f,
            17.2f,
            18.2f,
            20.1f,
            22.1f,
            24.1f,
            24.3f,
            25.1f,
            25.3f,
            26.1f,
            26.3f,
            27.1f,
            27.3f,
            30.1f,
            30.1f,
            31.1f,
            31.1f,
            32.1f,
            32.1f,
            33.1f,
            33.1f,
            33.3f,
            34.1f,
            34.3f,
            35.1f,
            35.3f,
            36.3f,
            37.1f,
            35.3f,
            36.1f,
            36.3f,
            37.1f,
            37.3f,
        };

        [Button]
        public static void GetBeatData(List<float> beatDataList, DirectionName directionName)
        {
            foreach (var beatData in beatDataList)
            {
                var decimalPoint = Mathf.Repeat(beatData, 1.0f);
                var wholePoint = beatData - (decimalPoint);
                
                var beat = wholePoint * 4 + (decimalPoint * 10) - 16;

                beat = Mathf.Round(beat);

                if (RootManager.BeatDirectionDictionary.ContainsKey(beat))
                {
                    RootManager.BeatDirectionDictionary[beat] |= directionName;
                }
                else
                {
                    RootManager.BeatDirectionDictionary.Add(beat, directionName);
                }
            }
        }
    }
}