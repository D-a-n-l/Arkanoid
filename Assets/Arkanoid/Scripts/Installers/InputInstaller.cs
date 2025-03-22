using UnityEngine;
using MiniIT.Input;
using Zenject;

namespace MiniIT.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                Container.BindInterfacesAndSelfTo<MobileInput>().AsSingle();
            }
            else
            {
                Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
            }
        }
    }
}