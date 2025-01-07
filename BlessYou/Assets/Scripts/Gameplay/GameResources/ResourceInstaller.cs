using UnityEngine;
using Zenject;

namespace Gameplay.GameResources
{
    public class ResourceInstaller : MonoInstaller
    {

        [SerializeField]
        private PlayerGoldManager _playerGoldManager;

        [SerializeField]
        private GoldSettings _goldSettings;

        [SerializeField]
        private PlayerGoldView _goldView;

        public override void InstallBindings()
        {
            Container.Bind<PlayerGoldManager>().FromInstance(_playerGoldManager).AsSingle();
            Container.Bind<GoldSettings>().FromInstance(_goldSettings).AsSingle();
            Container.Bind<PlayerGoldView>().FromInstance(_goldView).AsSingle();
        }
    }
}