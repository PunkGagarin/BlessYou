using System.Collections.Generic;
using Gameplay.DayResults;
using Gameplay.Treatment.Beds;
using UnityEngine;
using Zenject;

namespace Gameplay.Results
{

    /// <summary>
    /// Отвечает за результаты лечения и дальнейшую судьбу пациентов
    /// </summary>
    public class TreatmentResultManager : MonoBehaviour
    {

        [Inject] private BedManager _bedManager;
        [Inject] private PlayerGoldManager _goldManager;

        public TreatmentResultInfo CurrentTreatmentResults { get; private set; } = new();

        public void CalculateResults()
        {
            CurrentTreatmentResults = new TreatmentResultInfo();
            List<Patient> patients = _bedManager.GetAllPatientsInBeds();
            int goldResult = 0;

            foreach (Patient patient in patients)
            {
                // Get AnamnesisCard
                // Get heal result depends on AnamenesisCard

                bool treatmentResultFor = GetTreatmentResultFor(patient);
                
                Debug.Log($"Patient {patient} is healed or dead: {treatmentResultFor} ");
                patient.IsHealed = treatmentResultFor;
                patient.IsDead = !treatmentResultFor;

                if (patient.IsHealed)
                {
                    goldResult += _goldManager.AddGoldForHealedPatient(patient);
                    CurrentTreatmentResults.HealedPatients++;
                    CurrentTreatmentResults.HealedPatientsList.Add(patient);
                }
                else if (patient.IsDead)
                {
                    goldResult += _goldManager.GetPenaltyForDeadPatient(patient);
                    CurrentTreatmentResults.DeadPatients++;
                    CurrentTreatmentResults.DeadPatientsList.Add(patient);
                }
            }
            CurrentTreatmentResults.GoldDifference = goldResult;

            _bedManager.CleanBeds();
        }

        private bool GetTreatmentResultFor(Patient patient)
        {
            //todo: implement me????
            return Random.value > 0.5f;
        }
    }

}