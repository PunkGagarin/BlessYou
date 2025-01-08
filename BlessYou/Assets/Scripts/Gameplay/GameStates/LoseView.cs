using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Results
{
    public class LoseView : MonoBehaviour
    {

        [SerializeField]
        private GameObject _content;

        [field: SerializeField]
        public Button RestartButton { get; private set; }

        public void Show()
        {
            _content.SetActive(true);
        }
    }
}