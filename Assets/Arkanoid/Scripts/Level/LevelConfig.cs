using UnityEngine;
using MiniIT.Presets;

namespace MiniIT.Level
{
    [CreateAssetMenu(fileName = "Level Config", menuName = "Configs/Level")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField]
        public MovablePreset      Platform { get; private set; } = new MovablePreset();

        [field: SerializeField]
        public BouncablePreset    Ball { get; private set; } = new BouncablePreset();

        [field: SerializeField]
        public GameObjectPreset[] Crashables { get; private set; } = new GameObjectPreset[1];
    }
}