using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class NewspaperInstaller : MonoInstaller
    {
        
        [SerializeField]
        private NewspaperView _newspaperView;
        
        [SerializeField]
        private NewspaperManager _newspaperManager;
        public override void InstallBindings()
        {
            Container.Bind<NewspaperView>().FromInstance(_newspaperView).AsSingle();
            Container.Bind<NewspaperManager>().FromInstance(_newspaperManager).AsSingle();
        }
    }
}