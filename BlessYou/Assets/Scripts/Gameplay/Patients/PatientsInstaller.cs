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
        private InitialExaminationView _initialExaminationView;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PatientQueueSettings>().FromInstance(patientQueueSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<PatientQueueManager>().FromInstance(_queueManager).AsSingle();
            Container.BindInterfacesAndSelfTo<PatientQueueView>().FromInstance(_patientQueueView).AsSingle();
            
            Container.BindInterfacesAndSelfTo<InitialExaminationManager>().FromInstance(_initialExaminationManager)
                .AsSingle();
            Container.BindInterfacesAndSelfTo<InitialExaminationView>().FromInstance(_initialExaminationView)
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<PatientGenerator>().AsSingle();
        }
    }
}