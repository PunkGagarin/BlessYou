﻿using System;
using System.Collections.Generic;
using Gameplay.Patients.InitialExam;
using UnityEngine;
using Zenject;

namespace Gameplay.Patients.PatientQueue
{
    public class PatientQueueManager : MonoBehaviour
    {

        [Inject] private PatientQueueView _view;
        [Inject] private PatientQueueSettings _queueSettings;
        [Inject] private PatientGenerator _patientGenerator;
        [Inject] private InitialExaminationManager _initialExaminationManager;

        private readonly List<Patient> _patients = new();

        private Patient _currentPatient;

        public event Action EndOfPatientQueue = delegate { };

        private void Awake()
        {
            _view.NextPatientButton.onClick.AddListener(ShowNextPatientUI);
            _view.OnTimerEnds += OnPatientTimerEnds;
            _initialExaminationManager.OnPatientDistributed += OnPatientDistributed;
        }

        private void OnDestroy()
        {
            _view.NextPatientButton.onClick.AddListener(ShowNextPatientUI);
            _view.OnTimerEnds -= OnPatientTimerEnds;
            _initialExaminationManager.OnPatientDistributed -= OnPatientDistributed;
        }
        
        private void ShowNextPatientUI()
        {
            //todo: create patient AnamnesisCard
            _initialExaminationManager.StartExaminationFor(_currentPatient);
        }
        
        private void OnPatientTimerEnds()
        {
            _initialExaminationManager.KickOutPatient();
        }
        
        private void OnPatientDistributed()
        {
            _patients.RemoveAt(0);
            if (_patients.Count == 0)
            {
                HideNextPatientButton();
                EndOfPatientQueue.Invoke();
                return;
            }

            ProceedNextPatient();
        }

        public void HideNextPatientButton()
        {
            _view.Hide();
        }

        public void StartPatientQueue(int currentDay)
        {
            GeneratePatientsForCurrentDay(currentDay);
            _view.Show();
            ProceedNextPatient();
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
            Debug.Log($"Proceed next patient");
            _currentPatient = _patients[0];
            // _patients.RemoveAt(0);
            _view.MoveLine();
            var randomTime = _queueSettings.GetRandomQueueTime();
            _view.SetTimer(randomTime);
        }

        public bool HasPatientsInQueue()
        {
            return _patients.Count > 0;
        }
    }
}