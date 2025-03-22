using MiniIT.Core;
using NaughtyAttributes;
using UnityEngine;

namespace MiniIT.Level
{
    [CreateAssetMenu(fileName = "Level Config", menuName = "Configs/Level")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField]
        public Movable Platform { get; private set; } = null;

        [field: SerializeField]
        public Bouncable Ball { get; private set; } = null;

        [field: SerializeField]
        public CrashablePreset[] Crashables { get; private set; } = new CrashablePreset[1];

        [Button]
        public void InitBlocks()
        {
            foreach (CrashablePreset crashable in Crashables)
            {
                Instantiate(crashable.Prefab, crashable.Position, Quaternion.Euler(crashable.Rotation));
            }
        }
    }

    [System.Serializable]
    public struct CrashablePreset
    {
        public Crashable Prefab;

        public Vector3 Position;

        public Vector3 Rotation;
    }
}