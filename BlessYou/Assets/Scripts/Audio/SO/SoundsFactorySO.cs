using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Audio
{

    [CreateAssetMenu(menuName = "Gameplay/Audio/SoundsFactorySO", fileName = "SoundsFactorySO")]
    public class SoundsFactorySO : ScriptableObject
    {
        [SerializeField]
        private List<CustomKeyValue<GameAudioType, List<AudioClip>>> _clips;

        public AudioClip GetRandomClipByType(GameAudioType type)
        {
            AudioClip clipToReturn = null;
            var audioList = _clips.FirstOrDefault(el => el.Key == type);
            if (audioList != null)
            {
                clipToReturn = audioList.Value[Random.Range(0, audioList.Value.Count)];
            }
            
            if (clipToReturn == null)
            {
                Debug.LogError("Clip not found: " + type);
            }
            
            return clipToReturn;
        }

        public AudioClip GetClipByTypeAndIndex(GameAudioType type, int index)
        {
            AudioClip clipToReturn = null;
            var audioList = _clips.FirstOrDefault(el => el.Key == type);
            
            if (audioList != null)
            {
                clipToReturn = audioList.Value[index];
            }
            
            if (clipToReturn == null)
            {
                Debug.LogError("Clip not found: " + type);
            }
            
            return clipToReturn;
        }
    }

}