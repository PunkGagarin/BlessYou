using Gameplay.Inventory.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Inventory
{
    public class InstrumentSlotUI : BaseSlotUI<InstrumentType>
    {

        [SerializeField]
        private Image _unlockedImage;

        [SerializeField]
        private Image _lockedImage;

        public void Unlock()
        {
            if (_unlockedImage == null) return;

            _unlockedImage.gameObject.SetActive(true);
            _lockedImage.gameObject.SetActive(false);
            var dragHandler = GetComponent<SlotDragHandler<InstrumentType>>();
            dragHandler.CanDrag = true;
        }

        public void Lock()
        {
            if (_unlockedImage == null) return;

            _lockedImage.gameObject.SetActive(true);
            _unlockedImage.gameObject.SetActive(false);
            var dragHandler = GetComponent<SlotDragHandler<InstrumentType>>();
            dragHandler.CanDrag = false;
        }
    }

}