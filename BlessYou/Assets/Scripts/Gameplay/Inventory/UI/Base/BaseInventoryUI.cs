using System;
using System.Collections.Generic;
using Gameplay.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Inventory.UI
{
    public abstract class BaseInventoryUI<T, S> : MonoBehaviour where S : BaseSlotUI<T>
    {
        [SerializeField]
        private List<S> _initialSlot;
        //
        // [field: SerializeField]
        // public Button CloseButton { get; private set; }

        public List<S> InitialSlots
        {
            get => _initialSlot;
            set => _initialSlot = value;
        }

        private Dictionary<T, S> _items = new();

        public event Action<T> OnInstrumentClicked = delegate { };

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            foreach (var slot in InitialSlots)
            {
                var type = slot.Type;
                _items.Add(type, slot);
            }
        }
    }
}