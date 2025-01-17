using Gameplay.Base;
using Gameplay.Patients.Generation;
using Gameplay.Patients.InitialExam;
using Gameplay.Patients.Treatment;
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

        [SerializeField]
        private PatientTreatmentVisualizer _visualizer;

        public void ShowPatientInfo(Patient patient)
        {
            Show();
            _patientInfoUI.SetInfo(patient);
            _visualizer.SetVisual(patient.Visual);
        }
    }
}