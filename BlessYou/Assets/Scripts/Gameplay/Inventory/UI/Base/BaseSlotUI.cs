using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Inventory.UI.Base
{
    public class BaseSlotUI<T> : MonoBehaviour
    {
        
        [SerializeField]
        private TextMeshProUGUI _nameText;
        
        [SerializeField]
        protected Image _icon;

        // [field: SerializeField]
        // public Button Button { get; private set; }

        [field: SerializeField]
        public T Type { get; private set; }
        
        public void SetSprite(Sprite soIcon)
        {
            _icon.sprite = soIcon;
        }

        private void Awake()
        {
            _nameText.text = Type.ToString();
        }
    }
}