using MiniIT.Level;
using UnityEngine;

[CreateAssetMenu(fileName = "All Levels Config", menuName = "Configs/All Levels")]
public class AllLevelsConfig : ScriptableObject
{
    [field: SerializeField]
    public LevelConfig[] Levels { get; private set; } = new LevelConfig[1];
}