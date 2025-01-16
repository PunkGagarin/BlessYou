using System.Collections.Generic;
using Gameplay.Patients.Diseases;
using UnityEngine;

namespace Gameplay.Treatment
{
    public class GlossaryUI : MonoBehaviour
    {

        [SerializeField]
        private List<GlossaryDiseasePanel> _diseasePanels;

        [SerializeField]
        private GlossaryDiseasePanel _panelPrefab;

        [SerializeField]
        private Transform _contentParent;

        public void SetDiseases(List<DiseaseSO> diseases)
        {
            for (int index = 0; index < diseases.Count; index++)
            {
                var disease = diseases[index];

                if (index >= _diseasePanels.Count)
                {
                    var panelInst = Instantiate(_panelPrefab, _contentParent);
                    _diseasePanels.Add(panelInst);
                }

                var panel = _diseasePanels[index];

                panel.SetDiseaseHealInfo(disease.Name,
                    disease.HealInfo.InstrumentType,
                    disease.HealInfo.MedicamentType);
            }

            if (_diseasePanels.Count > diseases.Count)
            {
                TurnOffPanels(diseases.Count);
            }
        }

        private void TurnOffPanels(int diseasesCount)
        {
            for (int index = diseasesCount; index < _diseasePanels.Count; index++)
            {
                _diseasePanels[index].gameObject.SetActive(false);
            }
        }

    }
}