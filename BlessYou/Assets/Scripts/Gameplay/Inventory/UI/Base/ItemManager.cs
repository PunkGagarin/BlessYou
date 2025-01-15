using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Inventory.UI.Base
{
    public abstract class ItemManager<T, TUI, TS> : IInitializable, IDisposable
        where TUI : BaseInventoryUI<T, TS> where TS : BaseSlotUI<T>
    {
        [Inject] private TUI _instrumentaryUI;

        public void Initialize()
        {
            var slots = _instrumentaryUI.InitialSlots;

            foreach (var slot in slots)
            {
                slot.GetComponent<SlotDragHandler<T>>().OnItemDropped += OnItemDrop;
            }
        }

        public void Dispose()
        {
            var slots = _instrumentaryUI.InitialSlots;
            foreach (var slot in slots)
            {
                slot.GetComponent<SlotDragHandler<T>>().OnItemDropped -= OnItemDrop;
            }
        }

        protected virtual void OnItemDrop(T type)
        {
            Debug.Log("On item dropped on proper area");
        }
    }
}