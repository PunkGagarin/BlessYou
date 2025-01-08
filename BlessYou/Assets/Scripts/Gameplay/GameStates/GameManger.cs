using System;
using SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Gameplay.Results
{
    public class GameManger : MonoBehaviour
    {

        [Inject] private LoseView _loseView;
        [Inject] private Loader _loader;

        private void Awake()
        {
            _loseView.RestartButton.onClick.AddListener(RestartGame);
        }

        private void OnDestroy()
        {
            _loseView.RestartButton.onClick.RemoveListener(RestartGame);
        }

        private void RestartGame()
        {
            _loader.Load(Scenes.GamePlayScene);
        }

        public void LoseGame()
        {
            _loseView.Show();
        }
    }

}