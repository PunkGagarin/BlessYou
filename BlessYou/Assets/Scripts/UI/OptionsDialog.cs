using Audio;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class OptionsDialog : BaseUIObject
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundSlider;
        
        [Inject] private SoundManager soundManager;
        [Inject] private MusicManager musicManager;
        
        private void Awake()
        {
            closeButton.onClick.AddListener(OnCloseButtonClicked);
            musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
            soundSlider.onValueChanged.AddListener(OnSoundSliderValueChanged);
            Hide();
        }


        private void Start()
        {
            soundSlider.value = soundManager.Volume;
            musicSlider.value = musicManager.Volume;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnCloseButtonClicked();
            }
        }

        private void OnDestroy()
        {
            closeButton.onClick.RemoveListener(OnCloseButtonClicked);
            musicSlider.onValueChanged.RemoveListener(OnMusicSliderValueChanged);
            soundSlider.onValueChanged.RemoveListener(OnSoundSliderValueChanged);
        }

        private void OnCloseButtonClicked()
        {
            Hide();
        }

        private void OnMusicSliderValueChanged(float value)
        {
            musicManager.ChangeVolume(value);
        }
        
        private void OnSoundSliderValueChanged(float value)
        {
            soundManager.ChangeVolume(value);
        }

    }
}