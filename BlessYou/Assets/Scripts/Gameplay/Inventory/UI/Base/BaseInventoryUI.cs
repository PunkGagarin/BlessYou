using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Inventory.UI.Base
{
    public abstract class BaseInventoryUI<T, S> : MonoBehaviour where S : BaseSlotUI<T>
    {
        [SerializeField]
        private List<S> _initialSlot;

        public List<S> InitialSlots
        {
            get => _initialSlot;
            set => _initialSlot = value;
        }
    }
}