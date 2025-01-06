using UnityEngine;
using Zenject;

namespace Gameplay.GameResources
{
    public class ResourceInstaller : MonoInstaller
    {

        [SerializeField]
        private PlayerGoldManager _playerGoldManager;

        public override void InstallBindings()
        {
            Container.Bind<PlayerGoldManager>().FromInstance(_playerGoldManager).AsSingle();
        }
    }
}