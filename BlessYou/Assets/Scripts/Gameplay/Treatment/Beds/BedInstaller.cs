using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.Treatment.Beds
{
    public class BedInstaller : MonoInstaller
    {
        
        [FormerlySerializedAs("_bedSpotManager")] [SerializeField]
        private BedManager bedManager;

        [SerializeField]
        private BedSettings _bedSettings;

        public override void InstallBindings()
        {
            Container.Bind<BedSettings>().FromInstance(_bedSettings).AsSingle();
            Container.Bind<BedManager>().FromInstance(bedManager).AsSingle();
        }
        
    }
}