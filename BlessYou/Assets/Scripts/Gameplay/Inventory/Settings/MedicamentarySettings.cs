using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Inventory.Settings
{
    // [CreateAssetMenu(menuName = "Gameplay/Settings/MedicamentarySettings", fileName = "MedicamentarySettings")]
    public class MedicamentarySettings : ScriptableObject
    {
        [SerializeField]
        private List<CustomKeyValue<MedicamentType, int>> _buyPrice;

        //todo: надо ли?
        // [field: SerializeField]
        // private int MaxStackCount { get; set; } = 10;

        public int GetUnlockPriceFor(MedicamentType medType)
        {
            var customKeyValue = _buyPrice.FirstOrDefault(x => x.Key == medType);
            if (customKeyValue == null)
            {
                Debug.LogError($"There is no unlock price for {medType}");
            }
            return customKeyValue?.Value ?? default;
        }
    }
}