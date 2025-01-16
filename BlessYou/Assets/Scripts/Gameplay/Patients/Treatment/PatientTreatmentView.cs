using Gameplay.Base;
using Gameplay.Patients.InitialExam;
using Gameplay.Patients.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Treatment
{
    public class PatientTreatmentView : ContentUI
    {
        [field: SerializeField]
        public Button CloseButton { get; private set; }

        [SerializeField]
        private PatientInfoUI _patientInfoUI;

        public void ShowPatientInfo(Patient patient)
        {
            Show();
            _patientInfoUI.SetInfo(patient);
        }
    }
}