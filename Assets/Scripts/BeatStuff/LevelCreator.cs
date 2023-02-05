using System;
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
            8.2f,
            8.4f,
            9.2f,
            9.4f,
            19.4f,
            20.4f,
            21.4f,
            22.4f,
            24.2f,
            24.4f,
            26.2f,
            26.4f,
            30.1f,
            30.3f,
            31.1f,
            31.3f,
            32.1f,
            32.3f,
            33.1f,
            33.3f,
            34.2f,
            34.4f,
            36.2f,
            36.4f
        };
        
        public static List<float> W = new List<float>
        {
            4.2f,
            4.4f,
            5.2f,
            5.4f,
            15.3f,
            16.3f,
            19.2f,
            21.2f,
            24.1f,
            24.3f,
            25.1f,
            25.3f,
            26.1f,
            26.3f,
            27.1f,
            27.3f,
            34.1f,
            34.3f,
            35.1f,
            35.3f,
            36.1f,
            36.3f,
            37.1f,
            37.3f
        };

        public static List<float> S = new List<float>
        {
            6.2f,
            6.4f,
            7.2f,
            7.4f,
            15.2f,
            15.4f,
            16.2f,
            16.4f,
            17.2f,
            17.4f,
            18.2f,
            18.4f,
            19.3f,
            20.3f,
            21.3f,
            22.3f,
            25.1f,
            25.4f,
            27.1f,
            27.4f,
            30.4f,
            31.4f,
            32.4f,
            35.1f,
            37.1f,
            37.4f,
        };

        public static List<float> D = new List<float>()
        {
            10.2f,
            10.4f,
            11.2f,
            11.4f,
            17.3f,
            18.3f,
            20.2f,
            22.2f,
            24.2f,
            24.4f,
            25.2f,
            25.4f,
            26.2f,
            26.4f,
            27.2f,
            27.4f,
            30.1f,
            30.2f,
            31.1f,
            31.2f,
            32.1f,
            32.2f,
            33.1f,
            33.2f,
            33.4f,
            34.2f,
            34.4f,
            35.2f,
            36.4f,
            37.2f,
            35.4f,
            36.2f,
            36.4f,
            37.2f,
            37.4f,
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