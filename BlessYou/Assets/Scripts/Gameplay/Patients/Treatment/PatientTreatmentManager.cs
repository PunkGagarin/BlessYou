using System;
using System.Collections.Generic;
using Gameplay.Beds;
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

        private (Patient patient, BedSpotView bed) _bedWithCurrentPatient;

        public event Action EndOfTreatment = delegate { };

        private void Start()
        {
            _bedManager.OnBedWithPatientInteracted += ShowPatientTreatmentView;
            _bedManager.OnBedTimerEnds += FinishCurrentTreatmentPhase;
            _instrumentaryManager.OnItemDropped += TryUseInstrument;
            _medicamentaryManager.OnItemDropped += TryUseMedicament;
            _view.CloseButton.onClick.AddListener(HideUI);
        }

        private void OnDestroy()
        {
            _bedManager.OnBedWithPatientInteracted -= ShowPatientTreatmentView;
            _bedManager.OnBedTimerEnds -= FinishCurrentTreatmentPhase;
            _instrumentaryManager.OnItemDropped += TryUseInstrument;
            _medicamentaryManager.OnItemDropped += TryUseMedicament;
            _view.CloseButton.onClick.RemoveListener(HideUI);
        }

        private void FinishCurrentTreatmentPhase(Patient patient, BedSpotView view, BedInfo bedInfo)
        {
            if (view == _bedWithCurrentPatient.bed)
                HideUI();

            if (bedInfo.CurrentTreatmentType == TreatmentType.View)
            {
                // Patient is Dead
                patient.IsDead = true;
                _treatmentResults.SetDeadPatient(patient);
                _bedManager.CleanBed(view);
            }
            else
            {
                patient.IsHealed = true;
                _treatmentResults.SetHealedPatient(patient);
                _bedManager.CleanBed(view);
            }
            CheckDayForFinish();
        }

        private void CheckDayForFinish()
        {
            bool hasNoPatientsOnBeds = _bedManager.HasNoPatientsLeft();
            bool hasPatientsInQueue = _patientQueue.HasPatientsInQueue();

            if (!hasPatientsInQueue && hasNoPatientsOnBeds)
            {
                EndOfTreatment.Invoke();
            }
        }

        private void TryUseInstrument(InstrumentType type)
        {
            var patient = _bedWithCurrentPatient.patient;
            var diseaseInfo = patient.Disease;
            if (type == diseaseInfo.HealInfo.InstrumentType)
            {
                patient.HasTreatedByInstrument = true;
                Debug.Log("мы лечим правильным инструментом");
                if (HasNoTreatmentNeeds(patient))
                    StartTreatmentForCurrentPatient();
            }
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
            _bedManager.StartHealFor(_bedWithCurrentPatient.bed);
        }

        private void TryUseMedicament(MedicamentType type)
        {
            var patient = _bedWithCurrentPatient.patient;
            var diseaseInfo = patient.Disease;
            if (type == diseaseInfo.HealInfo.MedicamentType)
            {
                patient.HasTreatedByMedicament = true;
                Debug.Log("мы лечим правильным медикаментом");
                if (HasNoTreatmentNeeds(patient))
                    StartTreatmentForCurrentPatient();
            }
        }

        private void HideUI()
        {
            _view.Hide();
        }

        private void HealPatient()
        {
            Debug.Log("Назначили пациенту лечение пациента");
            _bedWithCurrentPatient.bed.TurnOffInteract();
            _bedWithCurrentPatient.patient.HasTreatment = true;
            _view.Hide();

            EndTreatmentIfNoPatientsLeft();
        }

        private void EndTreatmentIfNoPatientsLeft()
        {
            if (_bedManager.AllPatientsHealed())
                EndOfTreatment.Invoke();
        }

        private void ShowPatientTreatmentView(Patient patient, BedSpotView bed)
        {
            _bedWithCurrentPatient = (patient, bed);
            _view.ShowPatientInfo(patient);
        }

        public void StartPatientTreatment()
        {
            EndTreatmentIfNoPatientsLeft();
        }
    }
}