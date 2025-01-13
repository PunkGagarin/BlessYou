using System;
using Gameplay.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Patients.PatientQueue
{
    public class PatientQueueView : ContentUI
    {

        [field: SerializeField]
        public Button NextPatientButton { get; private set; }

        [SerializeField]
        private PatientTimerUI _patientTimerUI;
        
        public event Action OnTimerEnds = delegate { };

        private void Awake()
        {
            _patientTimerUI.OnTimerEnds += OnTimerEnds;
        }
        
        private void OnDestroy()
        {
            _patientTimerUI.OnTimerEnds -= OnTimerEnds;
        }

        public void MoveLine()
        {
            //todo: implement visual effects
        }

        public void SetTimer(float maxTimer)
        {
            _patientTimerUI.SetTimer(maxTimer);
        }
    }
}