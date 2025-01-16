using System;
using Gameplay.GameResources;
using Gameplay.Treatment.Beds;
using UnityEngine;
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

        private int _bedsUnlocked = 0;

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
            SetButtonStatuses();
        }

        private void SetButtonStatuses()
        {
            int bedCost = _bedSettings.GetBedPrice(_bedsUnlocked);
            bool canBuyBed = _playerGoldManager.HasEnoughMoney(bedCost) && _bedManager.HasBedsToUnlock();
            _ui.UnlockNewBedButton.interactable = canBuyBed;
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
            _bedsUnlocked++;
            
            SetBedButtonStatus();
        }

        private void SetBedButtonStatus()
        {
            if (_bedManager.HasBedsToUnlock())
            {
                int newPrice = _bedSettings.GetBedPrice(_bedsUnlocked);
                _ui.SetBedPrice(newPrice);
            }
            else
            {
                _ui.UnlockNewBedButton.interactable = false;
            }
        }
    }
}