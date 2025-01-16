﻿using System;
using Gameplay.GameResources;
using Gameplay.Inventory;
using Gameplay.Inventory.Settings;
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

        [Inject]
        private MedicamentRepository _medicamentRepository;

        [Inject]
        private MedicamentaryManager _medicamentaryManager;

        private int _bedsUnlocked = 0;

        public void Initialize()
        {
            _ui.UnlockNewBedButton.onClick.AddListener(UnlockNewBed);
            _ui.CloseShopButton.onClick.AddListener(CloseShop);
            _goldUi.GoldButton.onClick.AddListener(ShowShop);
            foreach (var slot in _ui.MedicamentSlotUIs)
            {
                slot.OnButtonClicked += BuyMedicament;
            }

            InitUi();
        }

        public void Dispose()
        {
            _ui.UnlockNewBedButton.onClick.RemoveListener(UnlockNewBed);
            _ui.CloseShopButton.onClick.RemoveListener(CloseShop);
            _goldUi.GoldButton.onClick.RemoveListener(ShowShop);
        }


        private void InitUi()
        {
            int initialBedPrice = _bedSettings.GetBedPrice(0);
            _ui.SetBedPrice(initialBedPrice);

            foreach (var slot in _ui.MedicamentSlotUIs)
            {
                var icon = _medicamentRepository.GetByType(slot.Type).Icon;
                slot.SetSprite(icon);
                int price = _medicamentRepository.GetPriceFor(slot.Type);
                slot.SetPriceText(price);
                int count = _medicamentaryManager.GetItemCount(slot.Type);
                slot.SetCount(count);
            }
        }

        private void BuyMedicament(MedicamentType type)
        {
            _playerGoldManager.SpendGold(_medicamentRepository.GetPriceFor(type));
            int newCount = _medicamentaryManager.AddItem(type);
            _ui.SetMedCountFor(type, newCount);
            SetButtonStatuses();
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

            foreach (var slot in _ui.MedicamentSlotUIs)
            {
                int goldPrice = _medicamentRepository.GetPriceFor(slot.Type);
                bool hasGold = _playerGoldManager.HasEnoughMoney(goldPrice);
                slot.SetButtonState(hasGold);
            }
        }

        private void CloseShop()
        {
            _ui.Hide();
        }

        private void UnlockNewBed()
        {
            _bedManager.UnlockNewBed();
            _bedsUnlocked++;
            
            // SetBedButtonStatus();
            SetButtonStatuses();
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