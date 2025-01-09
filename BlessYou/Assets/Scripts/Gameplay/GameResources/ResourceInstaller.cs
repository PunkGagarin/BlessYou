using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.GameResources
{
    public class ResourceInstaller : MonoInstaller
    {

        [SerializeField]
        private PlayerGoldManager _playerGoldManager;

        [SerializeField]
        private GoldSettings _goldSettings;

        [FormerlySerializedAs("_goldView")] [SerializeField]
        private PlayerGoldUI goldUI;

        public override void InstallBindings()
        {
            Container.Bind<PlayerGoldManager>().FromInstance(_playerGoldManager).AsSingle();
            Container.Bind<GoldSettings>().FromInstance(_goldSettings).AsSingle();
            Container.Bind<PlayerGoldUI>().FromInstance(goldUI).AsSingle();
        }
    }
}