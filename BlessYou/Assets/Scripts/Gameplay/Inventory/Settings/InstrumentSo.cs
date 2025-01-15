using UnityEngine;

namespace Gameplay.Inventory.Settings
{
    [CreateAssetMenu(menuName = "Gameplay/Content/Instrument", fileName = "New Instrument")]
    public class InstrumentSo : ScriptableObject
    {
        [field: SerializeField]
        public int PriceToBuy { get; private set; }

        [field: SerializeField]
        public int StartCount { get; private set; }

        [field: SerializeField]
        public MedicamentType Type { get; private set; }
        
        [field: SerializeField]
        public bool IsUnlockedByDefault { get; private set; }
    }
}