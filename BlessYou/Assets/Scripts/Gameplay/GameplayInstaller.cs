using Gameplay.Treatment;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {

        [SerializeField]
        private DayCycleManager dayCycleManager;

        [SerializeField]
        private EndDayButtonView _endDayButtonView;

        public override void InstallBindings()
        {
            Container.Bind<DayCycleManager>().FromInstance(dayCycleManager).AsSingle();
            Container.Bind<EndDayButtonView>().FromInstance(_endDayButtonView).AsSingle();
        }

    }
}