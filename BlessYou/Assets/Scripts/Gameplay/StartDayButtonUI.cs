using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class StartDayButtonUI : MonoBehaviour
    {
        
        
        
        [field: SerializeField]
        public Button EndDayButton { get; private set; }
        
        [field: SerializeField]
        public GameObject Arrow { get; private set; }

        private void Start()
        {
            EndDayButton.onClick.AddListener(HideArrow);
        }

        private void OnDestroy()
        {
            EndDayButton.onClick.RemoveListener(HideArrow);
        }

        private void HideArrow()
        {
            Arrow.gameObject.SetActive(false);
        }

        public void Show()
        {
            EndDayButton.gameObject.SetActive(true);
        }

        //todo: call me?
        public void Hide()
        {
            EndDayButton.gameObject.SetActive(false);
        }
    }
}