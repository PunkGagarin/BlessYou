using Gameplay.Base;
using Gameplay.Patients.Treatment;
using Gameplay.Patients.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Patients.InitialExam
{

    public class InitialExaminationUI : ContentUI
    {

        [field: SerializeField]
        public Button AcceptButton { get; private set; }

        [field: SerializeField]
        public Button QuickHealButton { get; private set; }

        [field: SerializeField]
        public Button EventButton { get; private set; }

        [field: SerializeField]
        public Button RejectButton { get; private set; }

        [field: SerializeField]
        public Button CloseButton { get; private set; }

        [field: SerializeField]
        public PatientInfoUI PatientInfoUI { get; private set; }

        [field: SerializeField]
        private PatientTreatmentVisualizer _visualizer;

        public void ShowPatient(Patient patient)
        {
            Debug.Log("Показываем информацию о пациенте");
            PatientInfoUI.SetInfo(patient);
            _visualizer.SetVisual(patient.Visual);
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