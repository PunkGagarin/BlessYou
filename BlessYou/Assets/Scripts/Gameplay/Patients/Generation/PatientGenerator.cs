using System;
using Gameplay.Patients.Generation;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class PatientGenerator
    {
        [Inject] private PatientGenerationRepository _patientGenerationRepo;
        [Inject] private PatientVisualRepositorySo _visualRepo;

        public Patient GeneratePatient()
        {
            Patient patient = new Patient();

            var sex = (Sex)Random.Range(0, 2);

            patient.Sex = sex;
            patient.Name = _patientGenerationRepo.GetRandomNameForSex(sex);
            patient.Rank = _patientGenerationRepo.GetRandomRank();
            patient.Disease = _patientGenerationRepo.GetRandomDisease();
            patient.Age = Random.Range(18, 59);
            
            patient.Visual = _visualRepo.GetRandomVisualForPatient(patient);
            

            return patient;
        }
    }
}