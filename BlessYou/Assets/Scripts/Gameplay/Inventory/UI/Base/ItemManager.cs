using System;
using System.Collections.Generic;
using Gameplay.Inventory.Settings;
using UnityEngine;
using Zenject;

namespace Gameplay.Inventory.UI.Base
{
    public abstract class ItemManager<T, TUI, TS, TR> : MonoBehaviour
        where TUI : BaseInventoryUI<T, TS> where TS : BaseSlotUI<T> where TR : ScriptableObject
    {
        [Inject] protected TUI _instrumentaryUI;
        [Inject] protected TR _soRepository;
        
        public virtual void Start()
        {
            var slots = _instrumentaryUI.InitialSlots;

            foreach (var slot in slots)
            {
                Init(slot);
                slot.GetComponent<SlotDragHandler<T>>().OnItemDropped += OnItemDrop;
            }
        }

        protected abstract void Init(TS slot);

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