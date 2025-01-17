using SceneLoader;
using UI;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.UI
{
    public class PauseUi : BaseUIObject
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private OptionsUI optionsUI;

        [Inject] private Loader _loader;
        [Inject] private PauseManager _gameplayManager;

        private void Awake()
        {
            resumeButton.onClick.AddListener(OnResumeButtonClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            optionsButton.onClick.AddListener(OnOptionsButtonClicked);
            pauseButton.onClick.AddListener(OnPauseButtonClicked);
            Hide();
        }

        private void OnDestroy()
        {
            resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
            optionsButton.onClick.RemoveListener(OnOptionsButtonClicked);
            pauseButton.onClick.AddListener(OnPauseButtonClicked);
        }

        private void OnResumeButtonClicked()
        {
            _gameplayManager.SetUnpause();
            Hide();
        }

        private void OnMainMenuButtonClicked()
        {
            _gameplayManager.SetUnpause();
            _loader.Load(Scenes.MainMenuScene);
        }

        private void OnOptionsButtonClicked()
        {
            optionsUI.Show();
        }

        private void OnPauseButtonClicked()
        {
            _gameplayManager.SetPause();
            Show();
        }
    }
}