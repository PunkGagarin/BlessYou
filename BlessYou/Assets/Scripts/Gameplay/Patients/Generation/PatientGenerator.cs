using System;
using Gameplay.Patients.Generation;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class PatientGenerator
    {

        //todo: база из которой берём данные для генерации пациентов
        [Inject] private PatientGenerationRepository _patientGenerationRepo;

        public Patient GeneratePatient()
        {
            Patient patient = new Patient();

            var sex = (Sex)Random.Range(0, 2);

            patient.Sex = sex;
            patient.Name = _patientGenerationRepo.GetRandomNameForSex(sex);
            patient.Rank = (PatientRank)Random.Range(0, Enum.GetValues(typeof(PatientRank)).Length);
            patient.Disease = _patientGenerationRepo.GetRandomDisease();
            patient.Age = Random.Range(15, 59);

            //get random sprite
            return patient;
        }
    }
}