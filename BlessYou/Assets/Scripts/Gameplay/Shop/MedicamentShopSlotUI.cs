using System;
using Gameplay.Inventory;
using Gameplay.Inventory.UI.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Gameplay.Shop
{
    public class MedicamentShopSlotUI : MonoBehaviour
    {

        [SerializeField]
        private MedicamentSlotUI _medicamentSlot;

        [SerializeField]
        private TextMeshProUGUI _priceText;

        [field: SerializeField]
        public Button Button { get; private set; }

        public Action<MedicamentType> OnButtonClicked = delegate { };

        private void Awake()
        {
            Button.onClick.AddListener(InvokeOnButtonClicked());
        }
        
        private void OnDestroy()
        {
            Button.onClick.RemoveListener(InvokeOnButtonClicked());
        }

        private UnityAction InvokeOnButtonClicked()
        {
            return () => OnButtonClicked.Invoke(_medicamentSlot.Type);
        }

        public void SetPriceText(int price)
        {
            _priceText.text = price.ToString();
        }

        public void SetButtonState(bool isActive)
        {
            Button.interactable = isActive;
        }
        
        public MedicamentType Type => _medicamentSlot.Type;
        
        public void SetSprite(Sprite sprite) => _medicamentSlot.SetSprite(sprite);

        public void SetCount(int newCount)
        {
            _medicamentSlot.SetCount(newCount);
        }
    }
}