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
        }
    }
}