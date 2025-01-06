using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PatientQueueManager : MonoBehaviour
    {

        [Inject] private PatientQueueView _view;
        [Inject] private PatientQueueSo _queueSettings;
        [Inject] private PatientGenerator _patientGenerator;
        [Inject] private InitialExaminationManager _initialExaminationManager;

        private readonly List<Patient> _patients = new();

        public event Action EndOfPatientQueue = delegate { };

        private void Awake()
        {
            _view.NextPatientButton.onClick.AddListener(ProceedNextPatient);
        }
        
        private void OnDestroy()
        {
            _view.NextPatientButton.onClick.AddListener(ProceedNextPatient);
        }


        public void StartPatientQueue(int currentDay)
        {
            GeneratePatientsForCurrentDay(currentDay);
            _view.ShowIndicator();
        }

        private void GeneratePatientsForCurrentDay(int currentDay)
        {
            int patientsPerDay = _queueSettings.GetPatientsPerDay(currentDay);

            Debug.Log($"Generating {patientsPerDay} patients for day {currentDay}");
            for (int i = 0; i < patientsPerDay; i++)
                _patients.Add(_patientGenerator.GeneratePatient());
        }

        private void ProceedNextPatient()
        {
            if (_patients.Count == 0)
                Debug.LogError("There are no patients");

            var patient = _patients[0];
            _patients.RemoveAt(0);
            _view.MoveLine();

            if (_patients.Count == 0)
                EndOfPatientQueue.Invoke();

            _initialExaminationManager.StartExaminationFor(patient);
        }
    }

}