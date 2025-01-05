using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class EndDayButtonView : MonoBehaviour
    {

        [field: SerializeField]
        public Button EndDayButton { get; private set; }

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