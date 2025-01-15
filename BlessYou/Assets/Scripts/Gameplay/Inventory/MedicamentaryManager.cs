using System;
using Gameplay.Inventory.UI.Base;
using Zenject;

namespace Gameplay.Inventory
{
    public class MedicamentaryManager : ItemManager<MedicamentType, MedicamentaryUI, MedicamentBaseSlotUI>
    {
        
        

        protected override void OnItemDrop(MedicamentType type)
        {
            
        }
    }
}