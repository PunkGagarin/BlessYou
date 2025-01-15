using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Inventory.Settings
{
    // [CreateAssetMenu(menuName = "Gameplay/Settings/MedicamentarySettings", fileName = "MedicamentarySettings")]
    public class MedicamentRepository : ScriptableObject
    {
        [SerializeField]
        private List<MedicamentSo> _medicaments;

        //todo: надо ли?
        // [field: SerializeField]
        // private int MaxStackCount { get; set; } = 10;

        public int GetPriceFor(MedicamentType medType)
        {
            var customKeyValue = _medicaments.FirstOrDefault(x => x.Type == medType);
            if (customKeyValue == null)
            {
                Debug.LogError($"There is no unlock price for {medType}");
            }
            return customKeyValue != null ? customKeyValue.PriceToBuy : default;
        }
    }

}