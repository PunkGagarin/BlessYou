using Gameplay.Inventory;
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

        [SerializeField]
        private MedicamentaryUI _medicamentaryUI;

        [SerializeField]
        private InstrumentaryUI _instrumentaryUI;

        public override void InstallBindings()
        {
            Container.Bind<PatientTreatmentManager>().FromInstance(_patientTreatmentManager).AsSingle();
            Container.Bind<PatientTreatmentView>().FromInstance(_treatmentView).AsSingle();
            Container.Bind<GlossaryManager>().FromInstance(_glossaryManager).AsSingle();
            Container.Bind<GlossaryUI>().FromInstance(_glossaryUI).AsSingle();
            Container.Bind<InstrumentaryUI>().FromInstance(_instrumentaryUI).AsSingle();
            Container.Bind<MedicamentaryUI>().FromInstance(_medicamentaryUI).AsSingle();
            Container.Bind<MedicamentaryManager>().AsSingle();
            Container.Bind<InstrumentaryManager>().AsSingle();
        }

    }
}