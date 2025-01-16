using System;
using System.Collections.Generic;
using Gameplay.Inventory.Settings;
using Gameplay.Inventory.UI.Base;
using UnityEngine;
using Zenject;

namespace Gameplay.Inventory
{
    public class InstrumentaryManager :
        ItemManager<InstrumentType, InstrumentaryUI, InstrumentSlotUI, InstrumentRepository>
    {
        private readonly Dictionary<InstrumentType, InstrumentInfo> _items = new();

        protected override void Init(InstrumentSlotUI slot)
        {
            InstrumentSo so = _soRepository.GetByType(slot.Type);
            if (so.IsUnlockedByDefault)
                slot.Unlock();
            else
                slot.Lock();

            InstrumentInfo info = new InstrumentInfo();
            var type = slot.Type;
            _items.Add(type, info);

            info.SO = so;
            info.IsUnlocked = so.IsUnlockedByDefault;

            slot.SetSprite(so.Icon);
        }

        protected override void OnItemDrop(InstrumentType type)
        {
            Debug.Log("On instrument dropped on proper area, type: " + type);
            OnItemDropped.Invoke(type);
        }

        public bool HasItem(InstrumentType healInfoInstrumentType)
        {
            return healInfoInstrumentType == InstrumentType.None || _items.ContainsKey(healInfoInstrumentType);
        }
    }

}