using UnityEngine;
using MiniIT.CORE;
using MiniIT.SUPPORT;

namespace MiniIT.PRESETS
{
    [System.Serializable]
    public class MainSettingsPreset
    {
        public Vector3 Position = Vector3.zero;

        public Vector3 Rotation = Vector3.zero;
    }

    [System.Serializable]
    public class BouncablePreset : MainSettingsPreset
    {
        public Bouncable Prefab = null;
    }

    [System.Serializable]
    public class GameObjectPreset : MainSettingsPreset
    {
        public GameObject Prefab = null;
    }

    [System.Serializable]
    public struct AudioClipPreset
    {
        public AudioClip Clip;

        public MinMax    Pitch;
    }
}