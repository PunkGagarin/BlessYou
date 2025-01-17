using Gameplay.Patients.Generation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Patients.Treatment
{
    public class PatientTreatmentVisualizer : MonoBehaviour
    {

        [SerializeField]
        private Image _skinImage;

        [SerializeField]
        private Image _hairImage;

        [SerializeField]
        private Image _hairLineImage;

        [SerializeField]
        private Image _beardImage;

        [SerializeField]
        private Image _beardLineImage;

        [SerializeField]
        private Image _diseaseImage;

        public void SetVisual(PatientVisualInfo visual)
        {
            _skinImage.sprite = visual.SkinSprite;
            _hairImage.sprite = visual.HairSprite;
            _hairLineImage.sprite = visual.HairLine;
            _beardImage.sprite = visual.BeardSprite;
            _beardLineImage.sprite = visual.BeardLine;

            if (visual.DiseaseSprite != null)
            {
                _diseaseImage.gameObject.SetActive(true);
                _diseaseImage.sprite = visual.DiseaseSprite;
            }
            else
                _diseaseImage.gameObject.SetActive(false);
        }
    }
}