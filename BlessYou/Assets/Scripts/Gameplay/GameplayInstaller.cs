using Gameplay.Results;
using Gameplay.UI;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameplayInstaller : MonoInstaller
    {

        [SerializeField]
        private DayCycleManager dayCycleManager;
        
        [SerializeField]
        private StartDayButtonUI _startDayButtonUI;

        [SerializeField]
        private EndDayButtonView _endDayButtonView;

        [SerializeField]
        private GameManger _gameManger;

        [SerializeField]
        private LoseView _loseView;
        
        [SerializeField]
        private PauseUi _pauseUI;

        [SerializeField]
        private PauseManager _pauseManager;

        public override void InstallBindings()
        {
            Container.Bind<DayCycleManager>().FromInstance(dayCycleManager).AsSingle();
            Container.Bind<StartDayButtonUI>().FromInstance(_startDayButtonUI).AsSingle();
            Container.Bind<EndDayButtonView>().FromInstance(_endDayButtonView).AsSingle();
            Container.Bind<LoseView>().FromInstance(_loseView).AsSingle();
            Container.Bind<GameManger>().FromInstance(_gameManger).AsSingle();
            Container.Bind<PauseUi>().FromInstance(_pauseUI).AsSingle();
            Container.Bind<PauseManager>().FromInstance(_pauseManager).AsSingle();
        }
    }
}