using Gameplay.News;
using Gameplay.Treatment.Beds;
using UnityEngine;
using Zenject;

namespace Gameplay.DayResults
{
    /// <summary>
    /// Отвечает за результаты лечения и дальнейшую судьбу пациентов
    /// </summary>
    public class TreatmentResultManager : MonoBehaviour
    {
        [Inject] private BedManager _bedManager;
        [Inject] private PlayerGoldManager _goldManager;
        [Inject] private NewspaperManager _newspaperManager;


        private TreatmentResultInfo CurrentTreatmentResults { get; set; } = new();

        public void CalculateResults(int day)
        {
            int goldDifference = CurrentTreatmentResults.GoldDifference;

            _goldManager.AddGold(goldDifference);

            _bedManager.CleanBeds();
            _newspaperManager.GenerateDayNews(day, CurrentTreatmentResults);
            CurrentTreatmentResults = new();
        }

        public void SetDeadPatient(Patient patient)
        {
            int goldResult = _goldManager.GetGoldForDeadPatient(patient);
            CurrentTreatmentResults.GoldDifference += goldResult;
            CurrentTreatmentResults.DeadPatients++;
            CurrentTreatmentResults.DeadPatientsList.Add(patient);
            Debug.Log("Patient is dead");
        }

        public void SetHealedPatient(Patient patient)
        {
            int goldResult = _goldManager.GetGoldForHealedPatient(patient);
            CurrentTreatmentResults.GoldDifference += goldResult;
            CurrentTreatmentResults.HealedPatients++;
            CurrentTreatmentResults.HealedPatientsList.Add(patient);
            Debug.Log("Patient is healed");
        }

        public void SetKickedOutPatient(Patient currentPatient)
        {
            //todo: add multiplier
            SetDeadPatient(currentPatient);
        }
    }
}