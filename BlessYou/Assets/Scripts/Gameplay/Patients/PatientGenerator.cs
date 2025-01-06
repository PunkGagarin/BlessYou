using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PatientGenerator
    {
        
        //todo: база из которой берём данные для генерации пациентов
        // [Inject] private PatientVariantSo _patientVariantSo;

        public Patient GeneratePatient()
        {
            //todo: proper patient generation
            //get random sprite
            //get random disease
            //get random age
            //get random должность
            
            return new Patient();
        }

    }
}