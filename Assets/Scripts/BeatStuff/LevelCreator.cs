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
            10.3f,
            11.3f,
            12.3f,
            13.3f,
            14.2f,
            14.4f,
            15.2f,
            15.4f,
            16.2f,
            16.4f,
            17.2f,
            17.4f,
        };
        
        public static List<float> W = new List<float>
        {
            6.4f,
            7.2f,
            7.4f,
            8.2f,
            8.4f,
            9.2f,
            9.4f,
            10.2f,
            10.4f,
            11.2f,
            11.4f,
            12.2f,
            12.4f,
            13.2f,
            13.4f,
            14.1f,
            14.2f,
            14.3f,
            14.4f,
            15.1f,
            15.2f,
            15.3f,
            15.4f,
            16.1f,
            16.2f,
            16.3f,
            16.4f,
            17.1f,
            17.2f,
            17.3f,
            17.4f,
            18.1f
        };
        
        [Button]
        public static void GetBeatData(List<float> beatDataList, DirectionName directionName)
        {
            foreach (var beatData in beatDataList)
            {
                var decimalPoint = Mathf.Repeat(beatData, 1.0f);
                var wholePoint = beatData - (decimalPoint);
                
                var beat = wholePoint * 4 + (decimalPoint * 10);

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