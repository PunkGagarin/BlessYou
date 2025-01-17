using Audio;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class PauseManager : MonoBehaviour
    {
        [Inject] private PauseUi _pauseUi;
        [Inject] private MusicManager _musicManager;
        [Inject] private SoundManager _soundManager;

        private bool _isPaused;

        // private readonly bool _isPlaying = true;
        // public bool IsGamePlaying()
        // {
        //     return _isPlaying && !_isPaused;
        // }

        public void TogglePauseGame()
        {
            _isPaused = !_isPaused;
        }

        public void SetPause()
        {
            _isPaused = true;
            Time.timeScale = 0f;
        }
        
        public void SetUnpause()
        {
            _isPaused = false;
            Time.timeScale = 1f;
        }
    }
}