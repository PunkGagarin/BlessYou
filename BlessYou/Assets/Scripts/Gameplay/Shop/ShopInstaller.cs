using UnityEngine;
using Zenject;

namespace Gameplay.Shop
{
    public class ShopInstaller : MonoInstaller
    {
        
        [SerializeField]
        private GameShopUI _gameShopUI;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameShopUI>().FromInstance(_gameShopUI).AsSingle();
            Container.BindInterfacesAndSelfTo<GameShopManager>().AsSingle();
        }
    }
}