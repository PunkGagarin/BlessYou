using System;
using System.Collections.Generic;
using Gameplay.Inventory.UI.Base;
using UnityEngine;
using Zenject;

namespace Gameplay.Inventory
{
    public class InstrumentaryManager : ItemManager<InstrumentType, InstrumentaryUI, InstrumentSlotUI>
    {
        
        

        protected override void OnItemDrop(InstrumentType type)
        {
            Debug.Log("On instrument dropped on proper area");
        }
    }
}