using System;
using Gameplay.GameResources;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayerGoldManager : MonoBehaviour
    {

        [Inject] private GoldSettings _goldSettings;
        [Inject] private PlayerGoldView _goldView;

        private int _gold;

        private int Gold
        {
            get => _gold;
            set
            {
                _gold = value; 
                _goldView.SetGold(value);
            }
        }

        private void Awake()
        {
            Gold = _goldSettings.InitialGold;
        }

        public void AddGoldForHealedPatient(Patient patient)
        {
            Gold += _goldSettings.GoldPerHealed;
            Gold = Mathf.Clamp(Gold, 0, 9999);
        }

        public void GetPenaltyForDeadPatient(Patient patient)
        {
            Gold -= _goldSettings.GoldPerDead;
            Gold = Mathf.Clamp(Gold, 0, 9999);
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