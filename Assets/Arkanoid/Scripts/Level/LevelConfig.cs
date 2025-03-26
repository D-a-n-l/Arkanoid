using UnityEngine;
using MiniIT.Core;
using MiniIT.Presets;

namespace MiniIT.Level
{
    [CreateAssetMenu(fileName = "Level Config", menuName = "Configs/Level")]
    public class LevelConfig : ScriptableObject
    {
        [field: Min(0)]
        [field: SerializeField]
        public float              DelayBetweenSpawn = 1f;

        [field: SerializeField]
        public Movable            Platform { get; private set; } = null;

        [field: SerializeField]
        public BouncablePreset    Ball { get; private set; } = new BouncablePreset();

        [field: SerializeField]
        public GameObjectPreset[] Crashables { get; private set; } = new GameObjectPreset[1];
    }
}