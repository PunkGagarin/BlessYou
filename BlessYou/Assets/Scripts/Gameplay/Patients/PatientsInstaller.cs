using Gameplay.Patients.Generation;
using Gameplay.Patients.InitialExam;
using Gameplay.Patients.PatientQueue;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.Patients
{
    public class PatientsInstaller : MonoInstaller
    {

        [FormerlySerializedAs("_patientQueueSo")] [SerializeField]
        private PatientQueueSettings patientQueueSettings;

        [SerializeField]
        private PatientQueueManager _queueManager;

        [SerializeField]
        private PatientQueueView _patientQueueView;

        [SerializeField]
        private InitialExaminationManager _initialExaminationManager;

        [SerializeField]
        private InitialExaminationUI initialExaminationUI;

        [SerializeField]
        private PatientGenerationRepository _patientGenerationRepository;

        [SerializeField]
        private PatientVisualRepositorySo _patientVisualRepositorySo;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PatientQueueSettings>().FromInstance(patientQueueSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<PatientQueueManager>().FromInstance(_queueManager).AsSingle();
            Container.BindInterfacesAndSelfTo<PatientQueueView>().FromInstance(_patientQueueView).AsSingle();

            Container.BindInterfacesAndSelfTo<InitialExaminationManager>().FromInstance(_initialExaminationManager)
                .AsSingle();
            Container.BindInterfacesAndSelfTo<InitialExaminationUI>().FromInstance(initialExaminationUI)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<PatientGenerationRepository>().FromInstance(_patientGenerationRepository)
                .AsSingle();
            Container.BindInterfacesAndSelfTo<PatientVisualRepositorySo>().FromInstance(_patientVisualRepositorySo)
                .AsSingle();
            Container.BindInterfacesAndSelfTo<PatientGenerator>().AsSingle();
        }
    }
}