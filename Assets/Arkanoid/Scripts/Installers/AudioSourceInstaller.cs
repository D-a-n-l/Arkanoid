using UnityEngine;
using Zenject;

public class AudioSourceInstaller : MonoInstaller
{
    [SerializeField]
    private AudioSource source = null;

    public override void InstallBindings()
    {
        Container.Bind<AudioSource>().FromInstance(source);
    }
}