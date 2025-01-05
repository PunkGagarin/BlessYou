using UnityEngine;

namespace Audio
{
    public class MusicManager : BaseAudioManager
    {

        private const string PLAYER_PREFS_NAME = "MusicVolume";
        private const float DEFAULT_VOLUME = .5f;

        [SerializeField] private SoundsFactorySO soundsFactory;
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            SetPlayerPrefsName();
            Volume = PlayerPrefs.GetFloat(PLAYER_PREFS_NAME, DEFAULT_VOLUME);
            audioSource.volume = Volume;
        }
        
        public override void ChangeVolume()
        {
            base.ChangeVolume();
            audioSource.volume = Volume;
        }

        public override void ChangeVolume(float _volume)
        {
            Volume = _volume;
            ChangeVolume();
        }
        
        public void PlaySoundByType(GameAudioType type, int soundIndex)
        {
            var soundToPlay = soundsFactory.GetClipByTypeAndIndex(type, soundIndex);
            PlayBgm(soundToPlay);
        }
        
        private void PlayBgm(AudioClip clip, float volumeMultiplier = DEFAULT_VOLUME)
        {
            audioSource.clip = clip;
            audioSource.volume = volumeMultiplier * Volume;
            audioSource.loop = true;
            audioSource.Play();
        }
        
        protected override void SetPlayerPrefsName()
        {
            playerPrefsName = PLAYER_PREFS_NAME;
        }
    
    }
}