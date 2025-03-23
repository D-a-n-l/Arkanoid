using UnityEngine;
using MiniIT.Core;

namespace MiniIT.Presets
{
    [System.Serializable]
    public class MainSettingsPreset
    {
        public Vector3 Position = Vector3.zero;

        public Vector3 Rotation = Vector3.zero;
    }

    [System.Serializable]
    public class MovablePreset : MainSettingsPreset
    {
        public Movable Prefab = null;
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
}