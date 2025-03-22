using MiniIT.Core;
using NaughtyAttributes;
using UnityEngine;

namespace MiniIT.Level
{
    [CreateAssetMenu(fileName = "Level Config", menuName = "Configs/Level")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField]
        public GameObjectPreset   Platform { get; private set; } = new GameObjectPreset();

        [field: SerializeField]
        public GameObjectPreset   Ball { get; private set; } = new GameObjectPreset();

        [field: SerializeField]
        public GameObjectPreset[] Crashables { get; private set; } = new GameObjectPreset[1];

        [Button]
        public void InitBlocks()
        {
            foreach (GameObjectPreset crashable in Crashables)
            {
                Instantiate(crashable.Prefab, crashable.Position, Quaternion.Euler(crashable.Rotation));
            }
        }
    }

    [System.Serializable]
    public struct GameObjectPreset
    {
        public GameObject Prefab;

        public Vector3 Position;

        public Vector3 Rotation;
    }
}