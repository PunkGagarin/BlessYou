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

        public int FamilyDaysWithoutFood { get; private set; } = 0;

        public void TrySpendFamilyFood(int currentDay)
        {
            if (currentDay <= 1)
                return;
            int familyFoodCost = _familySettings.GetFamilyFoodCostForDay(FamilyDaysWithoutFood + 1);
            bool hasMoney = _goldManager.HasEnoughMoney(familyFoodCost);

            if (hasMoney)
                FeedFamily(familyFoodCost);
            else
                StarvateFamily();
        }

        private void FeedFamily(int familyFoodCost)
        {
            _goldManager.SpendGold(familyFoodCost);
            FamilyDaysWithoutFood = 0;
        }

        private void StarvateFamily()
        {
            FamilyDaysWithoutFood++;
            if (FamilyDaysWithoutFood >= _familySettings.FamilyDaysWithoutFood)
            {
                _gameManger.LoseGame();
            }
        }

    }
}