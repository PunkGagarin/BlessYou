using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Results
{
    // [CreateAssetMenu(menuName = "Gameplay/Settings/FamilySettings", fileName = "FamilySettings")]
    public class FamilySettings : ScriptableObject
    {

        [field: SerializeField]
        public int FamilyDaysWithoutFood { get; private set; } = 2;

        [SerializeField]
        private List<CustomKeyValue<int, int>> _familyCostPerDays = new()
        {
            new CustomKeyValue<int, int>(1, 50),
            new CustomKeyValue<int, int>(4, 100),
            new CustomKeyValue<int, int>(10, 150),
            new CustomKeyValue<int, int>(15, 200)
        };


        public int GetFamilyFoodCostForDay(int currentDay)
        {
            foreach ((int dayIndex, int patients) in _familyCostPerDays)
            {
                if (dayIndex >= currentDay)
                    return patients;
            }

            Debug.LogError($" day {currentDay} not found");
            return _familyCostPerDays[0].Value;
        }
    }
}