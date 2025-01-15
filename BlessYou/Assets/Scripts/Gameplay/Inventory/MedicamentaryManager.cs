using System.Collections.Generic;
using Gameplay.Inventory.Settings;
using Gameplay.Inventory.UI.Base;
using UnityEngine;

namespace Gameplay.Inventory
{
    public class MedicamentaryManager : 
        ItemManager<MedicamentType, MedicamentaryUI, MedicamentBaseSlotUI, MedicamentRepository>
    {
        protected Dictionary<MedicamentType, MedicamentInfo> _items = new();

        protected override void Init(MedicamentBaseSlotUI slot)
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
                Debug.Log("Потратили 1 медикамент");
                medicamentInfo.View.SetCount(medicamentInfo.CurrentCount);
            }
        }
    }

    public class MedicamentInfo
    {
        public MedicamentSo SO { get; set; }
        public int CurrentCount { get; set; }
        public MedicamentBaseSlotUI View { get; set; }
    }
}