using Audio;
using SceneLoader;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private MusicManager musicManager;

    [SerializeField]
    private SoundsFactorySO _soundsFactorySo;
    
    public override void InstallBindings()
    {
        Container.Bind<Loader>().AsSingle();
        Container.Bind<SoundManager>().FromInstance(soundManager).AsSingle();
        Container.Bind<MusicManager>().FromInstance(musicManager).AsSingle();
        Container.Bind<SoundsFactorySO>().FromInstance(_soundsFactorySo).AsSingle();
    }
    
}
