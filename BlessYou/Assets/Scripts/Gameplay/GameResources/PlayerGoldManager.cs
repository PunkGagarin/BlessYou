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

        public int GetPenaltyForDeadPatient(Patient patient)
        {
            int goldSettingsGoldPerDead = _goldSettings.GoldPerDead;
            Gold -= goldSettingsGoldPerDead;
            Gold = Mathf.Clamp(Gold, 0, 9999);
            return goldSettingsGoldPerDead;
        }

        public bool HasEnoughMoney(int familyFoodCost)
        {
            return _gold >= familyFoodCost;
        }

        public void SpendGold(int goldToSpend)
        {
            _gold -= goldToSpend;
        }
    }

}