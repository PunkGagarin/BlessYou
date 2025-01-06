using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Patients
{
    public class InitialExaminationView : MonoBehaviour
    {

        [SerializeField]
        private Button _acceptButton;

        [SerializeField]
        private GameObject _content;

        private void Awake()
        {
            _acceptButton.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            _acceptButton.onClick.AddListener(Hide);
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
    }
}