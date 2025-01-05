using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class NewspaperManager : MonoBehaviour
    {

        [Inject] private NewspaperView _view;
        // [Inject] private NewsEventDataProvider _newsEventDataProvider;
        
        public void GenerateDayNews(int currentDay)
        {
            throw new System.NotImplementedException();
            string dayNews = "Day " + currentDay + " news";
            _view.FillNews(dayNews);
            _view.ShowNewsIndicator();
        }
    }

}