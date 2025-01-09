using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Gameplay.Treatment.Beds
{
    // [CreateAssetMenu(menuName = "Gameplay/Settings/BedSettings", fileName = "BedSettings")]
    public class BedSettings : ScriptableObject
    {
        [field: SerializeField]
        public int InitialUnlockedBeds { get; private set; }

        [field: SerializeField]
        public int MaxBedCount { get; private set; } = 4;

        [field: SerializeField]
        public List<int> BedPrice { get; private set; } = new() { 300, 500 };

        private void Awake()
        {
            int currentMaxBed = BedPrice.Count + InitialUnlockedBeds;
            Assert.AreEqual(currentMaxBed, MaxBedCount, "Bed count mismatch");
        }

        public int GetBedPrice(int index)
        {
            if (index >= BedPrice.Count || index < 0)
            {
                Debug.LogError("Wring bed index to buy");
                return BedPrice[0];
            }
            return BedPrice[index];
        }
    }
}