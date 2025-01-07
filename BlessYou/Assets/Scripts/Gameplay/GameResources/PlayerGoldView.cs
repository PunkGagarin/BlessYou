using TMPro;
using UnityEngine;

namespace Gameplay.GameResources
{
    public class PlayerGoldView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _goldText;
        
        public void SetGold(int gold) => _goldText.text = gold.ToString();
    }
}