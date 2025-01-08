using Gameplay.DayResults;
using Gameplay.Results;
using UnityEngine;
using Zenject;

namespace Gameplay.TreatmentResults
{
    public class DayResultInstaller : MonoInstaller
    {

        [SerializeField]
        private TreatmentResultManager _manager;

        [SerializeField]
        private FamilyManager _familyManager;

        [SerializeField]
        private FamilySettings _familySettings;

        public override void InstallBindings()
        {
            Container.Bind<TreatmentResultManager>().FromInstance(_manager).AsSingle();
            Container.Bind<FamilyManager>().FromInstance(_familyManager).AsSingle();
            Container.Bind<FamilySettings>().FromInstance(_familySettings).AsSingle();
        }
    }
}