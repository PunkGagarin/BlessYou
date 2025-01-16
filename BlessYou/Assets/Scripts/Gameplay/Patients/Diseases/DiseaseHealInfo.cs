using System;
using Gameplay.Inventory;
using UnityEngine;

namespace Gameplay.Patients.Generation
{
    [Serializable]
    public class DiseaseHealInfo
    {
        [field: SerializeField]
        public InstrumentType InstrumentType { get; set; }

        [field: SerializeField]
        public MedicamentType MedicamentType { get; set; }

        [field: SerializeField]
        public MedicamentType ExtraMedType { get; set; }

        [field: SerializeField]
        public float HealTime { get; set; } = 30f;
        
        [field: SerializeField]
        public float TreatmentTime { get; set; } = 10f;
    }
}