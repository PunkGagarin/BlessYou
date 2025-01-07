using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Treatment
{
    public class PatientTreatmentView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _content;

        [field: SerializeField]
        public Button HealButton { get; private set; }

        private void Show()
        {
            _content.SetActive(true);
        }

        public void Hide()
        {
            _content.SetActive(false);
        }

        public void ShowPatientInfo(Patient patient)
        {
            Show();
        }
    }
}