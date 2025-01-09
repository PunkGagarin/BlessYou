using UnityEngine;
using Zenject;

namespace Gameplay.News
{
    public class NewspaperInstaller : MonoInstaller
    {
        [SerializeField]
        private NewspaperUI newspaperUI;

        [SerializeField]
        private TableView _tableView;

        public override void InstallBindings()
        {
            Container.Bind<NewspaperUI>().FromInstance(newspaperUI).AsSingle();
            Container.Bind<TableView>().FromInstance(_tableView).AsSingle();
            Container.BindInterfacesAndSelfTo<NewspaperManager>().AsSingle();
        }
    }
}