using MiniIT.Core;
using MiniIT.Level;
using UnityEngine;
using Zenject;

namespace MiniIT.Installers
{
    public class LevelConfigInstaller : MonoInstaller
    {
        [SerializeField]
        private LevelConfig levelConfig = null;

        public override void InstallBindings()
        {
            Container.Bind<LevelConfig>().FromInstance(levelConfig);

            Movable platform = Container.InstantiatePrefab(levelConfig.Platform.Prefab, levelConfig.Platform.Position, Quaternion.Euler(levelConfig.Platform.Rotation), null).GetComponent<Movable>();

            Container.Bind<Movable>().FromInstance(platform);

            Bouncable ball = Container.InstantiatePrefab(levelConfig.Ball.Prefab, levelConfig.Ball.Position, Quaternion.Euler(levelConfig.Ball.Rotation), platform.transform).GetComponent<Bouncable>();

            Container.Bind<Bouncable>().FromInstance(ball);
        }
    }
}