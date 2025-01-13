using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Inventory.Settings
{
    // [CreateAssetMenu(menuName = "Gameplay/Settings/InstrumentarySettings", fileName = "InstrumentarySettings")]
    public class InstrumentarySettings : ScriptableObject
    {
        [SerializeField]
        private List<CustomKeyValue<InstrumentType, int>> _unlockPrice;
        
        public int GetUnlockPriceFor(InstrumentType instrumentType)
        {
            var customKeyValue = _unlockPrice.FirstOrDefault(x => x.Key == instrumentType);
            if (customKeyValue == null)
            {
                Debug.LogError($"There is no unlock price for {instrumentType}");
            }
            return customKeyValue?.Value ?? default;
        }
    }
}