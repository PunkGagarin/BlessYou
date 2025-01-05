using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PatientQueueManager : MonoBehaviour
    {
        
        [Inject] private PatientQueueView _view;

        private List<Patient> _patients = new List<Patient>();

        public event Action EndOfPatientQueue = delegate { };


        public void StartPatientQueue()
        {
            GeneratePatientsForCurrentDay();
            _view.ShowIndicator();
        }
        
        public void GeneratePatientsForCurrentDay()
        {
            throw new System.NotImplementedException();
        }

        public Patient ProceedNextPatient()
        {
            if (_patients.Count == 0)
            {
                Debug.LogError("There are no patients");
                return null;
            }

            var patient = _patients[0];
            _patients.RemoveAt(0);
            _view.MoveLine();

            if (_patients.Count == 0)
                EndOfPatientQueue.Invoke();

            return patient;
        }
    }

}