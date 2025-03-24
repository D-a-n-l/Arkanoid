using MiniIT.Core;
using MiniIT.Level;
using UnityEngine;
using Zenject;

namespace MiniIT.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private LevelConfig levelConfig = null;

        public override void InstallBindings()
        {
            Container.Bind<LevelConfig>().FromInstance(levelConfig);

            Movable platform = Container.InstantiatePrefabForComponent<Movable>(levelConfig.Platform.Prefab, levelConfig.Platform.Position, Quaternion.Euler(levelConfig.Platform.Rotation), null);

            Container.Bind<Movable>().FromInstance(platform);

            Bouncable ball = Container.InstantiatePrefabForComponent<Bouncable>(levelConfig.Ball.Prefab, levelConfig.Ball.Position, Quaternion.Euler(levelConfig.Ball.Rotation), null);

            ball.transform.SetParent(platform.transform, false);

            //ball.transform.position = levelConfig.Ball.Position;

            Container.Bind<Bouncable>().FromInstance(ball);
        }
    }
}