using UnityEngine;

namespace Gameplay
{
    public class PauseManager : MonoBehaviour
    {
        public bool IsPaused { get; private set; }

        public void TurnOnPause() => IsPaused = true;
        public void TurnOffPause() => IsPaused = false;
    }
}