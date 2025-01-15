using Gameplay.Inventory.UI.Base;
using UnityEngine;

namespace Gameplay.Inventory
{
    public class MedicamentaryManager : ItemManager<MedicamentType, MedicamentaryUI, MedicamentBaseSlotUI>
    {

        

        protected override void OnItemDrop(MedicamentType type)
        {
            Debug.Log("On med dropped on proper area");
        }
    }
}