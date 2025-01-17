using System;
using Audio;
using Gameplay.GameResources;
using Gameplay.Patients.Generation;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerGoldManager : MonoBehaviour
    {

        [Inject] private GoldSettings _goldSettings;
        [Inject] private PlayerGoldUI _goldUI;
        [Inject] private SoundManager _soundManager;

        private int _gold;

        private int Gold
        {
            get => _gold;
            set
            {
                // Debug.Log($" Gold changed from {_gold} to {value}");
                _gold = value;
                _soundManager.PlaySoundByType(GameAudioType.Money, 0, Vector3.zero);
                _goldUI.SetGold(value);
            }
        }

        private void Awake()
        {
            Gold = _goldSettings.InitialGold;
        }

        public int AddGoldForHealedPatient(Patient patient)
        {
            int goldSettingsGoldPerHealed = _goldSettings.GoldPerHealed;
            Gold += goldSettingsGoldPerHealed;
            Gold = Mathf.Clamp(Gold, 0, 9999);
            return goldSettingsGoldPerHealed;
        }

        public int GetGoldForHealedPatient(Patient patient)
        {
            int baseGold = _goldSettings.GoldPerHealed;
            return GoldForPatient(patient, baseGold);
        }

        private int GoldForPatient(Patient patient, int baseGold)
        {
            int rank = (int)patient.Rank;
            float baseRankMultiplier = _goldSettings.RankMultiplier;

            float rankMultiplier = 1 + rank * baseRankMultiplier;
            float heavinessMultiplier = 1f;
            if (patient.Disease.HeavinessType == DiseaseHeavinessType.Heavy)
                heavinessMultiplier = 1.5f;

            float finalValue = baseGold * rankMultiplier * heavinessMultiplier;
            return Mathf.CeilToInt(finalValue);
        }

        public int GetGoldForDeadPatient(Patient patient)
        {
            int baseGold = _goldSettings.GoldPerDead;
            return -GoldForPatient(patient, baseGold);
        }

        public int GetPenaltyForDeadPatient(Patient patient)
        {
            int goldSettingsGoldPerDead = _goldSettings.GoldPerDead;
            Gold -= goldSettingsGoldPerDead;
            Gold = Mathf.Clamp(Gold, 0, 9999);
            return goldSettingsGoldPerDead;
        }

        public bool HasEnoughMoney(int familyFoodCost)
        {
            return Gold >= familyFoodCost;
        }

        public void SpendGold(int goldToSpend)
        {
            Gold -= goldToSpend;
            Gold = Mathf.Clamp(Gold, 0, 9999);
        }

        public void AddGold(int goldDifference)
        {
            Gold += goldDifference;
            Gold = Mathf.Clamp(Gold, 0, 9999);
        }
    }

}