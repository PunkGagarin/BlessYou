using System.Collections.Generic;
using Gameplay.Inventory.Settings;
using Gameplay.Inventory.UI.Base;
using UnityEngine;

namespace Gameplay.Inventory
{
    public class MedicamentaryManager :
        ItemManager<MedicamentType, MedicamentaryUI, MedicamentSlotUI, MedicamentRepository>
    {
        protected Dictionary<MedicamentType, MedicamentInfo> _items = new();

        protected override void Init(MedicamentSlotUI slot)
        {
            MedicamentInfo info = new MedicamentInfo();
            var medicamentType = slot.Type;
            _items.Add(medicamentType, info);
            MedicamentSo so = _soRepository.GetByType(medicamentType);
            slot.SetCount(so.StartCount);

            info.SO = so;
            info.CurrentCount = so.StartCount;
            info.View = slot;
        }

        protected override void OnItemDrop(MedicamentType type)
        {
            var medicamentInfo = _items[type];
            if (medicamentInfo.CurrentCount > 0)
            {
                medicamentInfo.CurrentCount--;
                Debug.Log("Потратили 1 медикамент, тип: " + type);
                medicamentInfo.View.SetCount(medicamentInfo.CurrentCount);
                OnItemDropped.Invoke(type);
            }
            else
                Debug.Log("Не хватает медикаментов, тип: " + type);
        }
    }

}