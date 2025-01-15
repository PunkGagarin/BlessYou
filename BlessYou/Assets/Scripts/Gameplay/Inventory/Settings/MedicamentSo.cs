using UnityEngine;

namespace Gameplay.Inventory.Settings
{
    [CreateAssetMenu(menuName = "Gameplay/Content/Medicament", fileName = "New Medicament")]
    public class MedicamentSo : ScriptableObject
    {

        [field: SerializeField]
        public MedicamentType Type { get; private set; }

        [field: SerializeField]
        public int PriceToBuy { get; private set; }

        [field: SerializeField]
        public int StartCount { get; private set; }

        [field: SerializeField]
        public Sprite Icon { get; private set; }
    }
}