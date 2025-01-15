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

        // [field: SerializeField]
        // public Button Button { get; private set; }

        [field: SerializeField]
        public T Type { get; private set; }

        private void Awake()
        {
            _nameText.text = Type.ToString();
        }
    }
}