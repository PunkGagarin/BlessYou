using UnityEngine;

namespace Gameplay.Inventory.Settings
{
    [CreateAssetMenu(menuName = "Gameplay/Content/Instrument", fileName = "New Instrument")]
    public class InstrumentSo : ScriptableObject
    {

        [field: SerializeField]
        public InstrumentType Type { get; private set; }

        [field: SerializeField]
        public int PriceToUnlock { get; private set; }
        
        [field: SerializeField]
        public int DayToUnlock { get; private set; }

        [field: SerializeField]
        public bool IsUnlockedByDefault { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }
    }
}