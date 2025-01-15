using Gameplay.Inventory.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Inventory
{
    public class InstrumentSlotUI : BaseSlotUI<InstrumentType>
    {

        [SerializeField]
        private Image _lockedImage;

        public void Unlock()
        {
            _icon.gameObject.SetActive(true);
            _lockedImage.gameObject.SetActive(false);
            var dragHandler = GetComponent<SlotDragHandler<InstrumentType>>();
            dragHandler.CanDrag = true;
        }

        public void Lock()
        {
            _lockedImage.gameObject.SetActive(true);
            _icon.gameObject.SetActive(false);
            var dragHandler = GetComponent<SlotDragHandler<InstrumentType>>();
            dragHandler.CanDrag = false;
        }
    }

}