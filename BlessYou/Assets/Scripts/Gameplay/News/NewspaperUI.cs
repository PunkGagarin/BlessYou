using Gameplay.Base;
using Gameplay.DayResults;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.News
{
    public class NewspaperUI : ContentUI
    {
        [SerializeField]
        private TextMeshProUGUI _newsHeader;

        [SerializeField]
        private TextMeshProUGUI _newsText;

        [SerializeField]
        private TextMeshProUGUI _eventText;

        [SerializeField]
        private GameObject _newsIndicator;

        [field: SerializeField]
        public Button CloseButton { get; private set; }

        public override void Show()
        {
            base.Show();
            _newsIndicator.SetActive(false);
        }

        public void ShowNewsIndicator()
        {
            _newsIndicator.gameObject.SetActive(true);
        }

        public void SetInfo(TreatmentResultInfo info, int familyDaysWithoutFood, int currentday)
        {
            ShowNewsIndicator();

            _newsHeader.text = $"Day {currentday}";
            _newsText.text = $"Healed patients: {info.HealedPatients}\n" +
                             $"Dead patients: {info.DeadPatients}\n" +
                             $"Gold difference: {info.GoldDifference}\n" +
                             $"Family cost: {info.FamilyCost}";

            if (familyDaysWithoutFood > 0)
                _newsText.text += $"\nFamily days without food: {familyDaysWithoutFood}";
            else
                _newsText.text += $"\nFamily is healthy";

            _eventText.text = "";
        }
    }
}