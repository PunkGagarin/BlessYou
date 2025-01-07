using UnityEngine;

namespace Gameplay
{
    public class Patient
    {
        //возраст
        //звание
        //Ивенты (тэги)
        public bool HasTreatment { get; set; }
        public Sprite patientSprite { get; set; }
        public bool IsHealed { get; set; }
        public bool IsDead { get; set; }
    }

}