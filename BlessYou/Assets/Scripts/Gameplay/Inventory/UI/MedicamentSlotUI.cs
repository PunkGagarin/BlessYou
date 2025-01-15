using Gameplay.Inventory.UI.Base;
using TMPro;
using UnityEngine;

namespace Gameplay.Inventory
{
    public class MedicamentSlotUI : BaseSlotUI<MedicamentType>
    {

        [SerializeField]
        private TextMeshProUGUI _countText;
        
        public void SetCount(int count)
        {
            _countText.text = count.ToString();
        }
    }
}