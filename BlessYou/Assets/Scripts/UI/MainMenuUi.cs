using Audio;
using SceneLoader;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MainMenuUi : MonoBehaviour
    {
        [SerializeField]
        private Button startGameButton;

        [SerializeField]
        private Button optionsButton;

        [SerializeField]
        private OptionsUI optionsUI;

        [Inject] private Loader loader;
        
        [Inject] private MusicManager _musicManager;

        private void Awake()
        {
            startGameButton.onClick.AddListener(OnStartGameClicked);
            optionsButton.onClick.AddListener(OnOptionsClicked);
            _musicManager.PlaySoundByType(GameAudioType.MainMenuBgm, 0);
        }

        private void OnOptionsClicked()
        {
            optionsUI.Show();
        }

        private void OnStartGameClicked()
        {
            loader.Load(Scenes.GamePlayScene);
        }

        private void OnDestroy()
        {
            startGameButton.onClick.RemoveListener(OnStartGameClicked);
            optionsButton.onClick.RemoveListener(OnOptionsClicked);
        }
    }
}