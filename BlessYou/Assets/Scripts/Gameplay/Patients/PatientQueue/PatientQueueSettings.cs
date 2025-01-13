using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    // [CreateAssetMenu(menuName = "Gameplay/Settings/PatientQueueSO", fileName = "PatientQueueSO")]
    public class PatientQueueSettings : ScriptableObject
    {
        [SerializeField]
        private int _defaultPatients = 5;
        
        [SerializeField]
        private List<CustomKeyValue<int, int>> _patientsPerDay = new()
        {
            new CustomKeyValue<int, int>(1, 3),
            new CustomKeyValue<int, int>(2, 5),
            new CustomKeyValue<int, int>(4, 7),
            new CustomKeyValue<int, int>(7, 10)
        };

        [SerializeField]
        private float _queueMinTimer = 20f;
        
        [SerializeField]
        private float _queueMaxTimer = 40f;

        public int GetPatientsPerDay(int currentDay)
        {
            foreach ((int dayIndex, int patients) in _patientsPerDay)
            {
                if (dayIndex >= currentDay)
                    return patients;
            }

            return _defaultPatients;
        }
        
        public float GetRandomQueueTime() => Random.Range(_queueMinTimer, _queueMaxTimer);
    }
}