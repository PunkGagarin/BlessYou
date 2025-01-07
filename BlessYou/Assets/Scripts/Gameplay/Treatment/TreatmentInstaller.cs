using UnityEngine;
using Zenject;

namespace Gameplay.Treatment
{
    public class TreatmentInstaller : MonoInstaller
    {

        [SerializeField]
        private PatientTreatmentManager _patientTreatmentManager;
        
        [SerializeField]
        private PatientTreatmentView _treatmentView;

        public override void InstallBindings()
        {
            Container.Bind<PatientTreatmentManager>().FromInstance(_patientTreatmentManager).AsSingle();
            Container.Bind<PatientTreatmentView>().FromInstance(_treatmentView).AsSingle();
        }
        
    }
}