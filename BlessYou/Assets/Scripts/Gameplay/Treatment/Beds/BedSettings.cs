using UnityEngine;

namespace Gameplay.Treatment.Beds
{
    [CreateAssetMenu(menuName = "Gameplay/Settings/BedSettings", fileName = "BedSettings")]
    public class BedSettings : ScriptableObject
    {
        [field: SerializeField]
        public int InitialUnlockedBeds { get; private set; }
    }
}