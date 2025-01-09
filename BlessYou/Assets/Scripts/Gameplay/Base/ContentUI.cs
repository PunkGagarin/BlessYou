using UnityEngine;

namespace Gameplay.Base
{
    public class ContentUI : MonoBehaviour
    {

        [SerializeField]
        private GameObject _content;

        public virtual void Show()
        {
            _content.SetActive(true);
        }
        
        public void Hide()
        {
            _content.SetActive(false);
        }
    }
}