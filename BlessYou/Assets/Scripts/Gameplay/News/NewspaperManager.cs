using System;
using Gameplay.DayResults;
using Gameplay.Results;
using UnityEngine;
using Zenject;

namespace Gameplay.News
{
    public class NewspaperManager : 
        IInitializable, IDisposable
    {

        [Inject] private NewspaperUI _ui;
        [Inject] private TreatmentResultManager _treatmentResult;
        [Inject] private TableView _tableView;
        [Inject] private FamilyManager _familyManager;
        // [Inject] private NewsEventDataProvider _newsEventDataProvider;

        public void Initialize()
        {
            _tableView.OnClicked += OpenNewsUi;
            _ui.CloseButton.onClick.AddListener(HideNewsUI);
        }

        public void Dispose()
        {
            _tableView.OnClicked -= OpenNewsUi;
            _ui.CloseButton.onClick.RemoveListener(HideNewsUI);
        }

        private void OpenNewsUi()
        {
            _ui.Show();
        }

        private void HideNewsUI()
        {
            _ui.Hide();
        }

        public void GenerateDayNews(int currentDay)
        {
            var treatResult = _treatmentResult.CurrentTreatmentResults;

            _ui.SetInfo(treatResult, _familyManager.FamilyDaysWithoutFood, currentDay);
        }
    }

}