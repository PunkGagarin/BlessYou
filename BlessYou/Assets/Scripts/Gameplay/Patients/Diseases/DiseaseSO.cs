using Gameplay.Patients.Generation;
using UnityEngine;

namespace Gameplay.Patients.Diseases
{
    [CreateAssetMenu(menuName = "Gameplay/Content/Disease", fileName = "New Disease")]
    public class DiseaseSO : ScriptableObject
    {
        [field: SerializeField]
        public DiseaseHeavinessType HeavinessType { get; set; }

        [field: SerializeField]
        public string Name { get; set; }

        [field: SerializeField]
        public DiseaseType Type { get; set; }

        [field: SerializeField]
        public DiseaseHealInfo HealInfo { get; set; }
    }
}