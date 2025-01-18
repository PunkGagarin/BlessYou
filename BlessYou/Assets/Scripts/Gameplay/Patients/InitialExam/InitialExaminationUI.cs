using Gameplay.Base;
using Gameplay.Patients.Generation;
using Gameplay.Patients.Treatment;
using Gameplay.Patients.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
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
        public TextMeshProUGUI QuickHealButtonText { get; private set; }

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

        [FormerlySerializedAs("_heavySicknessColor")] [SerializeField]
        private Color _color;

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

        public void SetQuickHealButtonStatus(bool quickHealButtonActive, string quickHealText,
            DiseaseHeavinessType diseaseHeavinessType)
        {
            if (diseaseHeavinessType == DiseaseHeavinessType.Light)
            {
                string hexColor = ColorUtility.ToHtmlStringRGBA(_color);

                string disTypeText = $"<color=#{hexColor}>{quickHealText}</color>";
                QuickHealButtonText.text = $"QuickHeal\n(-{disTypeText})";
            }
            else
            {
                QuickHealButtonText.text = "QuickHeal";
            }
            QuickHealButton.interactable = quickHealButtonActive;
        }
    }

}