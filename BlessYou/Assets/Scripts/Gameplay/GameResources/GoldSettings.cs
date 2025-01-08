using UnityEngine;

namespace Gameplay
{
    // [CreateAssetMenu(menuName = "Gameplay/Settings/GoldSettings", fileName = "GoldSettings")]
    public class GoldSettings : ScriptableObject
    {
        [field: SerializeField]
        public int InitialGold { get; private set; }

        [field: SerializeField]
        public int GoldPerHealed { get; private set; }

        [field: SerializeField]
        public int GoldPerDead { get; private set; }
    }
}