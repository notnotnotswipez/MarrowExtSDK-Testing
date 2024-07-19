using UnityEngine;

namespace SLZ.Marrow.Data
{
    [CreateAssetMenu(fileName = "AudioReverbData", menuName = "StressLevelZero/Audio Reverb Data", order = 2)]
    public class AudioReverbData : ScriptableObject
    {
        [System.Serializable]
        public struct ReverbData
        {
            public string paramName;
            public float paramValue;
            [HideInInspector]
            public float minRange;
            [HideInInspector]
            public float maxRange;
            public ReverbData(string name, float val, float min, float max)
            {
                paramName = name;
                paramValue = val;
                minRange = min;
                maxRange = max;
            }
        }

        public ReverbData[] reverbData = new ReverbData[]
        {
            new ReverbData("DryLevel", 0, -10000, 0),
            new ReverbData("Room", -10000, -10000, 0),
            new ReverbData("RoomHF", 0, -10000, 0),
            new ReverbData("DecayTime", 1, -0.1f, 20.0f),
            new ReverbData("DecayHFRatio", 0.5f, 0.1f, 2.0f),
            new ReverbData("Reflections", -10000f, -10000, 0f),
            new ReverbData("ReflectDelay", 0.02f, 0, 0.3f),
            new ReverbData("Reverb", 0, -10000, 2000),
            new ReverbData("ReverbDelay", 0.04f, -10000, 2000),
            new ReverbData("Diffusion", 100f, 0, 100),
            new ReverbData("Density", 100f, 0, 100),
            new ReverbData("HFReference", 5000f, 20, 20000),
            new ReverbData("RoomLF", 5000f, -10000, 0),
            new ReverbData("LFReference", 250.0f, 20, 1000),
        };
    }
}