using System;
using Gameplay.GameResources;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerGoldManager : MonoBehaviour
    {

        [Inject] private GoldSettings _goldSettings;
        [Inject] private PlayerGoldUI _goldUI;

        private int _gold;

        private int Gold
        {
            get => _gold;
            set
            {
                Debug.Log($" Gold changed from {_gold} to {value}");
                _gold = value; 
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
            return _goldSettings.GoldPerHealed;
        }
        
        public int GetGoldForDeadPatient(Patient patient)
        {
            return -_goldSettings.GoldPerDead;
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