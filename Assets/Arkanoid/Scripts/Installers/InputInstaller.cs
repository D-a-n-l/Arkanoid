using UnityEngine;
using MiniIT.INPUT;
using Zenject;

namespace MiniIT.INSTALLERS
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