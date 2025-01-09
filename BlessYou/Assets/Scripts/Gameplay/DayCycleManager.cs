using System;
using Gameplay.DayResults;
using Gameplay.News;
using Gameplay.Patients.PatientQueue;
using Gameplay.Results;
using Gameplay.Treatment;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class DayCycleManager : MonoBehaviour
    {
        [Inject] private TreatmentResultManager _treatmentResultManager;
        [Inject] private NewspaperManager _newspaperManager;
        [Inject] private PatientQueueManager _queueManager;
        [Inject] private PatientTreatmentManager _treatmentManager;
        [Inject] private EndDayButtonView _endDayButtonView;
        [Inject] private FamilyManager _familyManager;

        private int _currentDay;

        private void Start()
        {
            _queueManager.EndOfPatientQueue += StartTreatment;
            _treatmentManager.EndOfTreatment += ShowEndDayButton;
            _endDayButtonView.EndDayButton.onClick.AddListener(EndCurrentDay);

            StartNewDay();
        }

        private void OnDestroy()
        {
            _queueManager.EndOfPatientQueue -= StartTreatment;
            _treatmentManager.EndOfTreatment -= ShowEndDayButton;
            _endDayButtonView.EndDayButton.onClick.RemoveListener(EndCurrentDay);
        }

        private void StartNewDay()
        {
            _currentDay++;
            Debug.Log($"Начался новый день: {_currentDay}");

            CalculatePreviousDay();
            ClearPreviousDay();
            ShowNews();
            StartPatientQueue();
        }

        private void ClearPreviousDay()
        {
            _endDayButtonView.Hide();
        }

        private void CalculatePreviousDay()
        {
            _familyManager.TrySpendFamilyFood(_currentDay);
            _treatmentResultManager.CalculateResults();
        }

        private void ShowNews()
        {
            _newspaperManager.GenerateDayNews(_currentDay);
        }

        private void StartPatientQueue()
        {
            _queueManager.StartPatientQueue(_currentDay);
        }

        private void StartTreatment()
        {
            _treatmentManager.StartPatientTreatment();
        }

        private void ShowEndDayButton()
        {
            _endDayButtonView.Show();
        }

        private void EndCurrentDay()
        {
            Debug.Log($"День {_currentDay} закончился");
            StartNewDay();
        }
    }

}