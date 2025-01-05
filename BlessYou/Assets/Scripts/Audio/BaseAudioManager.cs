using UnityEngine;

namespace Audio
{

    public abstract class BaseAudioManager : MonoBehaviour
    {

        protected string playerPrefsName;

        public float Volume { get; protected set; }

        public virtual void ChangeVolume()
        {
            PlayerPrefs.SetFloat(playerPrefsName, Volume);
            PlayerPrefs.Save();
        }

        public virtual void ChangeVolume(float _volume)
        {
            Volume = _volume;
            ChangeVolume();
        }

        protected abstract void SetPlayerPrefsName();
    }

}