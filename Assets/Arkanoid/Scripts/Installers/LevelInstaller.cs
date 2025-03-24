using MiniIT.Core;
using MiniIT.Level;
using UnityEngine;
using Zenject;

namespace MiniIT.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private AllLevelsConfig   allLevels = null;

        public static LevelConfig CurrentLevel { get; private set; } = null;

        public override void InstallBindings()
        {
            RandomLevel(allLevels);

            Container.Bind<AllLevelsConfig>().FromInstance(allLevels);

            Movable platform = Container.InstantiatePrefabForComponent<Movable>(CurrentLevel.Platform.Prefab, CurrentLevel.Platform.Position, Quaternion.Euler(CurrentLevel.Platform.Rotation), null);

            Container.Bind<Movable>().FromInstance(platform);

            Bouncable ball = Container.InstantiatePrefabForComponent<Bouncable>(CurrentLevel.Ball.Prefab, CurrentLevel.Ball.Position, Quaternion.Euler(CurrentLevel.Ball.Rotation), null);

            ball.transform.SetParent(platform.transform, false);

            Container.Bind<Bouncable>().FromInstance(ball);
        }

        public static LevelConfig RandomLevel(AllLevelsConfig config)
        {
            int level = Random.Range(0, config.Levels.Length);

            while (config.Levels[level] == CurrentLevel)
            {
                level = Random.Range(0, config.Levels.Length);
            }

            return CurrentLevel = config.Levels[level];
        }
    }
}