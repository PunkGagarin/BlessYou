using System.Collections.Generic;
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


        public void CalculateResults()
        {
            List<Patient> patients = _bedManager.GetAllPatientsInBeds();
            foreach (var patient in patients)
            {
                // Get AnamnesisCard
                // Get heal result depends on AnamenesisCard
                // set isDead flag
                // give out reward for all alive and healed patients

                bool treatmentResultFor = GetTreatmentResultFor(patient);
                Debug.Log($"Patient {patient} is healed or dead: {treatmentResultFor} ");
                patient.IsHealed = treatmentResultFor;
                patient.IsDead = !treatmentResultFor;

                if (patient.IsHealed)
                {
                    _goldManager.AddGoldForHealedPatient(patient);
                }
                else if (patient.IsDead)
                {
                    _goldManager.GetPenaltyForDeadPatient(patient);
                }

                _bedManager.CleanBeds();
            }
        }

        private bool GetTreatmentResultFor(Patient patient)
        {
            return Random.value > 0.5f;
        }
    }
}