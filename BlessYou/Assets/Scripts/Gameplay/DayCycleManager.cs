using System;
using Gameplay.Treatment;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class DayCycleManager : MonoBehaviour
    {
        [Inject] private PlayerGoldManager _playerGoldManager;
        [Inject] private NewspaperManager _newspaperManager;
        [Inject] private PatientQueueManager _queueManager;
        [Inject] private PatientTreatmentManager _treatmentManager;
        [Inject] private EndDayButtonView _endDayButtonView;

        private int _currentDay;

        private void Awake()
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

            ClearPreviousDay();
            GiveRewardForPreviousDay();
            ShowNews();
            StartPatientQueue();
        }

        private void ClearPreviousDay()
        {
            _endDayButtonView.Hide();
        }

        private void GiveRewardForPreviousDay()
        {
            _playerGoldManager.GetRewardForPreviousDay();
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
            Debug.Log($"Закончился первичный осмотр, Началось лечение пациентов");
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