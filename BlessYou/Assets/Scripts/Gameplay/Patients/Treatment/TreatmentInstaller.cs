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

        [SerializeField]
        private GlossaryManager _glossaryManager;
        
        [SerializeField]
        private GlossaryUI _glossaryUI;

        public override void InstallBindings()
        {
            Container.Bind<PatientTreatmentManager>().FromInstance(_patientTreatmentManager).AsSingle();
            Container.Bind<PatientTreatmentView>().FromInstance(_treatmentView).AsSingle();
            Container.Bind<GlossaryManager>().FromInstance(_glossaryManager).AsSingle();
            Container.Bind<GlossaryUI>().FromInstance(_glossaryUI).AsSingle();
        }
        
    }
}