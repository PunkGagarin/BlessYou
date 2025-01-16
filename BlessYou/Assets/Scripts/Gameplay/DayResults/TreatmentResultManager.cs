using System.Collections.Generic;
using Gameplay.DayResults;
using Gameplay.News;
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
        [Inject] private NewspaperManager _newspaperManager;

        public TreatmentResultInfo CurrentTreatmentResults { get; private set; } = new();

        public void CalculateResults(int day)
        {
            int goldDifference = CurrentTreatmentResults.GoldDifference;

            if (goldDifference > 0)
                _goldManager.AddGold(goldDifference);
            else
                _goldManager.SpendGold(goldDifference);

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
    }

}