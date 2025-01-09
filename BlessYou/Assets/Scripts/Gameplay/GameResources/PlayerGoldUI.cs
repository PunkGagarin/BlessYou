using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.GameResources
{
    public class PlayerGoldUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _goldText;

        [field: SerializeField]
        public Button GoldButton { get; private set; }

        public void SetGold(int gold) => _goldText.text = gold.ToString();
    }
}