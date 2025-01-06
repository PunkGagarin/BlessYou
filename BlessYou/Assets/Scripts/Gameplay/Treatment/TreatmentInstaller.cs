using UnityEngine;
using Zenject;

namespace Gameplay.Treatment
{
    public class TreatmentInstaller : MonoInstaller
    {

        [SerializeField]
        private PatientTreatmentManager _patientTreatmentManager;

        public override void InstallBindings()
        {
            Container.Bind<PatientTreatmentManager>().FromInstance(_patientTreatmentManager).AsSingle();
        }
        
    }
}