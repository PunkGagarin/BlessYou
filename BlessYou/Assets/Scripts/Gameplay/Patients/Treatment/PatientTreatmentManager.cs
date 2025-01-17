﻿using System;
using System.Collections.Generic;
using Audio;
using Gameplay.Beds;
using Gameplay.DayResults;
using Gameplay.Inventory;
using Gameplay.Patients.PatientQueue;
using Gameplay.Results;
using Gameplay.Treatment.Beds;
using UnityEngine;
using Zenject;

namespace Gameplay.Treatment
{
    public class PatientTreatmentManager : MonoBehaviour
    {
        [Inject] private BedManager _bedManager;
        [Inject] private PatientTreatmentView _view;
        [Inject] private InstrumentaryManager _instrumentaryManager;
        [Inject] private MedicamentaryManager _medicamentaryManager;
        [Inject] private TreatmentResultManager _treatmentResults;
        [Inject] private PatientQueueManager _patientQueue;
        [Inject] private SoundManager _soundManager;

        private Patient _currentPatient;

        public event Action EndOfTreatment = delegate { };

        private void Start()
        {
            _bedManager.OnBedWithPatientInteracted += ShowPatientTreatmentView;
            _bedManager.OnBedTimerEnds += FinishCurrentTreatmentPhase;
            _instrumentaryManager.OnItemDropped += TryUseInstrument;
            _medicamentaryManager.OnItemDropped += TryUseMedicament;
            _view.CloseButton.onClick.AddListener(HideUI);
            _patientQueue.EndOfPatientQueue += EndTreatmentIfNoPatientsLeft;
        }

        private void OnDestroy()
        {
            _bedManager.OnBedWithPatientInteracted -= ShowPatientTreatmentView;
            _bedManager.OnBedTimerEnds -= FinishCurrentTreatmentPhase;
            _instrumentaryManager.OnItemDropped += TryUseInstrument;
            _medicamentaryManager.OnItemDropped += TryUseMedicament;
            _view.CloseButton.onClick.RemoveListener(HideUI);
            _patientQueue.EndOfPatientQueue -= EndTreatmentIfNoPatientsLeft;
        }

        private void ShowPatientTreatmentView(Patient patient)
        {
            _currentPatient = patient;
            _view.ShowPatientInfo(patient);
        }

        private void FinishCurrentTreatmentPhase(Patient patient)
        {
            if (patient == _currentPatient)
                HideUI();

            if (patient.CurrentTreatmentType == TreatmentType.View)
            {
                patient.IsDead = true;
                _treatmentResults.SetDeadPatient(patient);
                _bedManager.CleanBed(patient);
            }
            else
            {
                patient.IsHealed = true;
                _treatmentResults.SetHealedPatient(patient);
                _bedManager.CleanBed(patient);
            }
            CheckDayForFinish();
        }

        private void HideUI()
        {
            _view.Hide();
        }

        private void CheckDayForFinish()
        {
            bool hasNoPatientsOnBeds = _bedManager.HasNoPatientsLeft();
            bool hasPatientsInQueue = _patientQueue.HasPatientsInQueue();

            Debug.Log($"checking day for finish, " +
                      $"has no patients on beds: {hasNoPatientsOnBeds}, has patients in queue: {hasPatientsInQueue}");
            if (!hasPatientsInQueue && hasNoPatientsOnBeds)
                EndOfTreatment.Invoke();
        }

        private void TryUseInstrument(InstrumentType type)
        {
            var diseaseInfo = _currentPatient.Disease;
            if (type == diseaseInfo.HealInfo.InstrumentType)
            {
                _currentPatient.HasTreatedByInstrument = true;
                Debug.Log("мы лечим правильным инструментом");
                if (HasNoTreatmentNeeds(_currentPatient))
                    StartTreatmentForCurrentPatient();
            }
            TryUseInstrumentSound(type);
        }

        private void TryUseInstrumentSound(InstrumentType type)
        {
            var soundTypeToUse = SoundMapper.GetSoundForInstrument(type);
            if (soundTypeToUse != GameAudioType.None)
                _soundManager.PlayRandomSoundByType(soundTypeToUse, Vector3.zero);
        }

        private bool HasNoTreatmentNeeds(Patient patient)
        {
            bool hasInstrumentTreat = patient.Disease.HealInfo.InstrumentType == InstrumentType.None
                                      || patient.HasTreatedByInstrument;
            bool hasMedicamentTreat = patient.Disease.HealInfo.MedicamentType == MedicamentType.None
                                      || patient.HasTreatedByMedicament;

            return hasInstrumentTreat && hasMedicamentTreat;
        }

        private void StartTreatmentForCurrentPatient()
        {
            HideUI();
            _currentPatient.CurrentTreatmentType = TreatmentType.Healing;
            _bedManager.StartHealFor(_currentPatient);
        }

        private void TryUseMedicament(MedicamentType type)
        {
            var patient = _currentPatient;
            var diseaseInfo = patient.Disease;
            if (type == diseaseInfo.HealInfo.MedicamentType)
            {
                patient.HasTreatedByMedicament = true;
                Debug.Log("мы лечим правильным медикаментом");
                if (HasNoTreatmentNeeds(patient))
                    StartTreatmentForCurrentPatient();
            }
            TryUseMedicamentSound(type);
        }

        private void TryUseMedicamentSound(MedicamentType type)
        {
            var soundTypeToUse = SoundMapper.GetSoundForMedicament(type);
            if (soundTypeToUse != GameAudioType.None)
                _soundManager.PlayRandomSoundByType(soundTypeToUse, Vector3.zero);
        }

        private void EndTreatmentIfNoPatientsLeft()
        {
            if (_bedManager.AllPatientsHealed())
                EndOfTreatment.Invoke();
        }
    }
}