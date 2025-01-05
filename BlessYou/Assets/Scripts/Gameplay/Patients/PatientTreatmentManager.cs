using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PatientTreatmentManager : MonoBehaviour
    {

        private Dictionary<BedSpotView, Patient> _beds = new Dictionary<BedSpotView, Patient>();

        public event Action EndOfTreatment = delegate { };

        public void StartPatientTreatment()
        {
            foreach (var bed in _beds)
            {
                if (bed.Value != null)
                {
                    bed.Key.TurnOnInterract();
                }
            }
        }
    }
}