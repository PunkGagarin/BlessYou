using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Inventory.UI.Base
{
    public abstract class ItemManager<T, TUI, TS> : MonoBehaviour
        where TUI : BaseInventoryUI<T, TS> where TS : BaseSlotUI<T>
    {
        [Inject] private TUI _instrumentaryUI;
        
        protected Dictionary<T, TS> _items = new();

        public void Start()
        {
            var slots = _instrumentaryUI.InitialSlots;

            foreach (var slot in slots)
            {
                _items.Add(slot.Type, slot);
                slot.GetComponent<SlotDragHandler<T>>().OnItemDropped += OnItemDrop;
            }
        }

        public void OnDestroy()
        {
            var slots = _instrumentaryUI.InitialSlots;
            foreach (var slot in slots)
            {
                slot.GetComponent<SlotDragHandler<T>>().OnItemDropped -= OnItemDrop;
            }
        }

        protected virtual void OnItemDrop(T type)
        {
            
        }
    }
}