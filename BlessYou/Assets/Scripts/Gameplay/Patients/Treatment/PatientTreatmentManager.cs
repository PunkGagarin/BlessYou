using System;
using System.Collections.Generic;
using Gameplay.Treatment.Beds;
using UnityEngine;
using Zenject;

namespace Gameplay.Treatment
{
    public class PatientTreatmentManager : MonoBehaviour
    {
        [Inject] private BedManager _bedManager;
        [Inject] private PatientTreatmentView _view;

        private (Patient patient, BedSpotView bed) _bedWithCurrentPatient;

        public event Action EndOfTreatment = delegate { };

        private void Start()
        {
            _bedManager.OnBedWithPatientInteracted += ShowPatientTreatmentView;
            _view.CloseButton.onClick.AddListener(HideUI);
        }

        private void OnDestroy()
        {
            _bedManager.OnBedWithPatientInteracted -= ShowPatientTreatmentView;
            _view.CloseButton.onClick.RemoveListener(HideUI);
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