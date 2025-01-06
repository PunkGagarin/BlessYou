using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class PatientQueueView : MonoBehaviour
    {

        [field: SerializeField]
        public Button NextPatientButton { get; private set; }

        public void ShowIndicator()
        {
            NextPatientButton.gameObject.SetActive(true);
        }
        
        public void HideIndicator()
        {
            NextPatientButton.gameObject.SetActive(false);
        }

        public void MoveLine()
        {
            //todo: implement visual effects
        }
    }
}