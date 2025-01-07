using Gameplay.Results;
using UnityEngine;
using Zenject;

namespace Gameplay.TreatmentResults
{
    public class TreatmentResultInstaller : MonoInstaller
    {

        [SerializeField]
        private TreatmentResultManager _manager;
        
        public override void InstallBindings()
        {
            Container.Bind<TreatmentResultManager>().FromInstance(_manager).AsSingle();
        }
    }
}