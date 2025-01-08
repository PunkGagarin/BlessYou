using Gameplay.Results;
using UnityEngine;
using Zenject;

namespace Gameplay.DayResults
{
    public class FamilyManager : MonoBehaviour
    {

        [Inject] private PlayerGoldManager _goldManager;
        [Inject] private FamilySettings _familySettings;
        [Inject] private GameManger _gameManger;

        private int _familyDaysWithoutFood = 0;

        public void TrySpendFamilyFood(int currentDay)
        {
            if (currentDay <= 1)
                return;
            int familyFoodCost = _familySettings.GetFamilyFoodCostForDay(_familyDaysWithoutFood + 1);
            bool hasMoney = _goldManager.HasEnoughMoney(familyFoodCost);

            if (hasMoney)
                FeedFamily(familyFoodCost);
            else
                StarvateFamily();
        }

        private void FeedFamily(int familyFoodCost)
        {
            _goldManager.SpendGold(familyFoodCost);
            _familyDaysWithoutFood = 0;
        }

        private void StarvateFamily()
        {
            _familyDaysWithoutFood++;
            if (_familyDaysWithoutFood >= _familySettings.FamilyDaysWithoutFood)
            {
                _gameManger.LoseGame();
            }
        }

    }
}