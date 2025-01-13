using System;
using System.Collections.Generic;
using Gameplay.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Inventory.UI
{
    public abstract class BaseInventoryUI<T, S> : ContentUI where S : BaseSlotUI<T>
    {
        [SerializeField]
        private List<S> _initialSlot;

        [field: SerializeField]
        public Button CloseButton { get; private set; }

        private Dictionary<T, S> _items = new();

        public event Action<T> OnInstrumentClicked = delegate { };

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            foreach (var slot in _initialSlot)
            {
                var type = slot.Type;
                _items.Add(type, slot);
            }
        }
    }
}