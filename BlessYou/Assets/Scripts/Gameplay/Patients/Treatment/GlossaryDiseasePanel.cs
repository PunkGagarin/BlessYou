using TMPro;
using UnityEngine;

namespace Gameplay.Treatment
{
    public class GlossaryDiseasePanel : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _diseaseName;

        [SerializeField]
        private TextMeshProUGUI _instrumentText;

        [SerializeField]
        private TextMeshProUGUI _medicamentText;

        public void SetDiseaseHealInfo(string diseaseName, string instrument, string medicament)
        {
            _diseaseName.text = diseaseName;
            _instrumentText.text = instrument;
            _medicamentText.text = medicament;
        }
    }
}