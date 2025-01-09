using System;
using Gameplay.GameResources;
using Gameplay.Treatment.Beds;
using Zenject;

namespace Gameplay.Shop
{
    public class GameShopManager : IInitializable, IDisposable
    {
        [Inject]
        private PlayerGoldManager _playerGoldManager;

        [Inject]
        private GameShopUI _ui;

        [Inject]
        private BedSettings _bedSettings;

        [Inject]
        private BedManager _bedManager;

        [Inject]
        private PlayerGoldUI _goldUi;

        public void Initialize()
        {
            _ui.UnlockNewBedButton.onClick.AddListener(UnlockNewBed);
            _ui.CloseShopButton.onClick.AddListener(CloseShop);
            _goldUi.GoldButton.onClick.AddListener(ShowShop);

            InitUi();
        }

        public void Dispose()
        {
            _ui.UnlockNewBedButton.onClick.RemoveListener(UnlockNewBed);
            _ui.CloseShopButton.onClick.RemoveListener(CloseShop);
            _goldUi.GoldButton.onClick.RemoveListener(ShowShop);
        }

        private void ShowShop()
        {
            _ui.Show();
        }

        private void CloseShop()
        {
            _ui.Hide();
        }

        private void InitUi()
        {
            int initialBedPrice = _bedSettings.GetBedPrice(0);
            _ui.SetBedPrice(initialBedPrice);
        }

        private void UnlockNewBed()
        {
            _bedManager.UnlockNewBed();

            if (_bedManager.HasBedsToUnlock())
            {
                int newPrice = _bedSettings.GetBedPrice(_bedSettings.InitialUnlockedBeds);
                _ui.SetBedPrice(newPrice);
            }
            else
            {
                _ui.UnlockNewBedButton.interactable = false;
            }
        }
    }
}