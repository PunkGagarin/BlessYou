using Gameplay.Results;
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

        [SerializeField]
        private GameManger _gameManger;

        [SerializeField]
        private LoseView _loseView;

        public override void InstallBindings()
        {
            Container.Bind<DayCycleManager>().FromInstance(dayCycleManager).AsSingle();
            Container.Bind<EndDayButtonView>().FromInstance(_endDayButtonView).AsSingle();
            Container.Bind<LoseView>().FromInstance(_loseView).AsSingle();
            Container.Bind<GameManger>().FromInstance(_gameManger).AsSingle();
        }

    }
}