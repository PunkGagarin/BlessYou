using Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Core
{
    public class BaseSoundButton : MonoBehaviour
    {
        private Button button;
        
        [Inject] private SoundManager soundManager;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDestroy()
        {
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            soundManager.PlaySoundByType(GameAudioType.ButtonClick, 0, Vector3.zero);
        }
    }
}