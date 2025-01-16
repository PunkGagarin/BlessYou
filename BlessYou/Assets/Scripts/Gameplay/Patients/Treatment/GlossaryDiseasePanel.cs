using Gameplay.Inventory;
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

        public void SetDiseaseHealInfo(string diseaseName, InstrumentType instrument, MedicamentType medicament)
        {
            _diseaseName.text = diseaseName;
            if(instrument == InstrumentType.None)
                _instrumentText.gameObject.SetActive(false);
            _instrumentText.text = instrument.ToString();
            
            if(medicament == MedicamentType.None)
                _medicamentText.gameObject.SetActive(false);
            _medicamentText.text = medicament.ToString();
        }
    }
}