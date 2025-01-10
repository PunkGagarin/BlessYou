﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Shop
{
    public class GameShopUI : MonoBehaviour
    {

        [SerializeField]
        private TextMeshProUGUI _bedPriceText;

        [SerializeField]
        private GameObject _content;

        [field: SerializeField]
        public Button UnlockNewBedButton { get; private set; }

        [field: SerializeField]
        public Button CloseShopButton { get; private set; }

        public void SetBedPrice(int bedPrice)
        {
            _bedPriceText.text = bedPrice.ToString();
        }

        public void Show() => _content.SetActive(true);
        public void Hide() => _content.SetActive(false);


    }
}