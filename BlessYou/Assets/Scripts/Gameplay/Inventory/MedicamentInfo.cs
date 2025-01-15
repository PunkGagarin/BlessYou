using Gameplay.Inventory.Settings;

namespace Gameplay.Inventory
{
    public class MedicamentInfo
    {
        public MedicamentSo SO { get; set; }
        public int CurrentCount { get; set; }
        public MedicamentBaseSlotUI View { get; set; }
    }
}