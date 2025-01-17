using Audio;
using SceneLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MainMenuUi : MonoBehaviour
    {
        [SerializeField]
        private Button startGameButton;

        // [SerializeField]
        // private Button optionsButton;

        // [SerializeField] private Button selectLevelButton;
        // [SerializeField]
        // private OptionsDialog optionsDialog;

        // [SerializeField]
        // private SelectLevelUI selectLevelUI;

        // [SerializeField]
        // private Button resetProgressButton;

        [Inject] private Loader loader;
        // [Inject] private PlayStatManager _playStatManager;
        // [Inject] private MusicManager _musicManager;

        private void Awake()
        {
            startGameButton.onClick.AddListener(OnStartGameClicked);
            // optionsButton.onClick.AddListener(OnOptionsClicked);
            // resetProgressButton.onClick.AddListener(ResetProgress);
            // _musicManager.PlaySoundByType(GameAudioType.MainMenuBgm, 0);
        }

        private void Start()
        {
            CheckSelectLevelButtonVisibility();
            SetStartGameButtonText();
        }

        private void ResetProgress()
        {
            PlayerPrefs.DeleteAll();
            startGameButton.GetComponentInChildren<TextMeshProUGUI>().text = "Start Game";
        }

        private void SetStartGameButtonText()
        {
            // var IsAtLeastOneLevelCompleted = _playStatManager.IsGamePlayed();
            // startGameButton.GetComponentInChildren<TextMeshProUGUI>().text =
                // IsAtLeastOneLevelCompleted ? "Continue Game" : "Start Game";
        }

        private void CheckSelectLevelButtonVisibility()
        {
            var allLevelsCompleted = false; // todo _playStatManager.IsAllLevelsCompleted();
            // selectLevelButton.gameObject.SetActive(allLevelsCompleted);
        }

        // private void OnOptionsClicked()
        // {
        //     optionsDialog.Show();
        // }

        private void OnStartGameClicked()
        {
            Debug.Log("Start butotn clicked");
            loader.Load(Scenes.GamePlayScene);
        }

        // private void OnSelectLevelClicked()
        // {
        //     selectLevelUI.Show();
        // }

        private void OnDestroy()
        {
            startGameButton.onClick.RemoveListener(OnStartGameClicked);
            // optionsButton.onClick.RemoveListener(OnOptionsClicked);
            // // selectLevelButton.onClick.RemoveListener(OnSelectLevelClicked);
            // resetProgressButton.onClick.RemoveListener(ResetProgress);
        }
    }
}