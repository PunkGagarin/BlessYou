using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Patients.InitialExam
{
    
    public class InitialExaminationView : MonoBehaviour
    {

        [field: SerializeField]
        public Button AcceptButton { get; private set; }
        
        [field: SerializeField]
        public Button QuickHealButton { get; private set; }
        
        [field: SerializeField]
        public Button EventButton { get; private set; }
        
        [field: SerializeField]
        public Button RejectButton { get; private set; }

        [SerializeField]
        private GameObject _content;

        private void Awake()
        {
            AcceptButton.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            AcceptButton.onClick.AddListener(Hide);
        }

        public void Show()
        {
            _content.SetActive(true);
        }
        
        public void Hide()
        {
            _content.SetActive(false);
        }

        public void ShowPatient(Patient patient)
        {
            Debug.Log("Показываем информацию о пациенте");
            Show();
        }

        public void SetAcceptButtonStatus(bool acceptButtonActive)
        {
            AcceptButton.interactable = acceptButtonActive;
        }

        public void SetQuickHealButtonStatus(bool quickHealButtonActive)
        {
            QuickHealButton.interactable = quickHealButtonActive;
        }
    }
}