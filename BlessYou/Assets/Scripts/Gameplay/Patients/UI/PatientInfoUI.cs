using Gameplay.Patients.Diseases;
using Gameplay.Patients.Generation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Patients.UI
{
    public class PatientInfoUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI Name;

        [SerializeField]
        public Image PatientSprite;

        [SerializeField]
        public TextMeshProUGUI DiseaseInfo;

        [SerializeField]
        public TextMeshProUGUI Rank;

        [SerializeField]
        public TextMeshProUGUI Sex;

        [SerializeField]
        public TextMeshProUGUI Age;

        [SerializeField]
        private Color _heavySicknessColor;


        public void SetInfo(Patient patient)
        {
            Name.text = patient.Name;
            // PatientSprite.sprite = patient.PatientSprite;
            Rank.text = patient.Rank.ToString();
            Sex.text = patient.Sex.ToString();
            Age.text = patient.Age.ToString();

            SetDiseaseInfo(patient.Disease);
        }

        protected virtual void SetDiseaseInfo(DiseaseSO patientDisease)
        {
            var heavinessType = patientDisease.HeavinessType;
            string hexColor = ColorUtility.ToHtmlStringRGBA(_heavySicknessColor);

            string disTypeText = heavinessType == DiseaseHeavinessType.Heavy
                ? $"<color=#{hexColor}>{patientDisease.Type}</color>"
                : patientDisease.Type.ToString();

            DiseaseInfo.text = "I have a following problem: " + disTypeText;
        }
    }
}