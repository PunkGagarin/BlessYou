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
        [Inject] private StartDayButtonUI _startDayButtonUI;
        [Inject] private EndDayButtonView _endDayButtonUI;
        [Inject] private FamilyManager _familyManager;

        private int _currentDay;

        private void Start()
        {
            _queueManager.EndOfPatientQueue += StartTreatment;
            _treatmentManager.EndOfTreatment += ShowEndDayButton;
            _startDayButtonUI.EndDayButton.onClick.AddListener(StartPatientQueue);
            _endDayButtonUI.EndDayButton.onClick.AddListener(EndCurrentDay);

            StartNewDay();
        }

        private void OnDestroy()
        {
            _queueManager.EndOfPatientQueue -= StartTreatment;
            _treatmentManager.EndOfTreatment -= ShowEndDayButton;
            _startDayButtonUI.EndDayButton.onClick.RemoveListener(StartPatientQueue);
            _endDayButtonUI.EndDayButton.onClick.RemoveListener(EndCurrentDay);
        }

        private void StartNewDay()
        {
            _currentDay++;
            Debug.Log($"Начался новый день: {_currentDay}");

            CalculatePreviousDay();
            PrepareNewDayUI();
        }

        private void PrepareNewDayUI()
        {
            _endDayButtonUI.Hide();
            _queueManager.HideNextPatientButton();
            _startDayButtonUI.Show();
        }

        private void CalculatePreviousDay()
        {
            _familyManager.TrySpendFamilyFood(_currentDay);
            _treatmentResultManager.CalculateResults(_currentDay);
        }

        private void StartPatientQueue()
        {
            _startDayButtonUI.Hide();
            _queueManager.StartPatientQueue(_currentDay);
        }

        private void StartTreatment()
        {
            _treatmentManager.StartPatientTreatment();
        }

        private void ShowEndDayButton()
        {
            _endDayButtonUI.Show();
        }

        private void EndCurrentDay()
        {
            Debug.Log($"День {_currentDay} закончился");
            StartNewDay();
        }
    }

}