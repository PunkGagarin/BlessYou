using Gameplay.Patients.Diseases;
using Gameplay.Patients.Generation;
using UnityEngine;

namespace Gameplay
{
    public class Patient
    {
        public string Name { get; set; }

        //возраст
        //Ивенты (тэги)
        public bool HasTreatment { get; set; }
        public Sprite patientSprite { get; set; }
        public bool IsHealed { get; set; }
        public bool IsDead { get; set; }
        public DiseaseSO Disease { get; set; }
        public PatientRank Rank { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        public PatientVisualInfo Visual { get; set; }

        public bool HasTreatedByInstrument { get; set; }
        public bool HasTreatedByMedicament { get; set; }
    }

}