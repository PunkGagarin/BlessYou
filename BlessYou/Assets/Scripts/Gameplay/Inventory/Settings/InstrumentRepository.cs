using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Inventory.Settings
{
    // [CreateAssetMenu(menuName = "Gameplay/Settings/InstrumentarySettings", fileName = "InstrumentarySettings")]
    public class InstrumentRepository : ScriptableObject
    {
        [SerializeField]
        private List<InstrumentSo> _instruments;
        
        public int GetUnlockPriceFor(InstrumentType instrumentType)
        {
            var customKeyValue = _instruments.FirstOrDefault(x => x.Type == instrumentType);
            if (customKeyValue == null)
            {
                Debug.LogError($"There is no unlock price for {instrumentType}");
            }
            return customKeyValue?.PriceToUnlock ?? default;
        }


        public InstrumentSo GetByType(InstrumentType type)
        {
            return _instruments.FirstOrDefault(x => x.Type == type);
        }
    }
}