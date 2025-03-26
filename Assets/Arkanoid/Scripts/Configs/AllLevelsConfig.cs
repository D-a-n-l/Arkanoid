using UnityEngine;

namespace MiniIT.CONFIGS.LEVEL
{
    [CreateAssetMenu(fileName = "All Levels Config", menuName = "Configs/Level/All Levels")]
    public class AllLevelsConfig : ScriptableObject
    {
        [field: SerializeField]
        public LevelConfig[] Levels { get; private set; } = new LevelConfig[1];
    }
}