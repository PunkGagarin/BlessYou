using System;
using System.Collections.Generic;
using Gameplay.Treatment.Beds;
using UnityEngine;
using Zenject;

namespace Gameplay.Treatment
{
    public class PatientTreatmentManager : MonoBehaviour
    {

        [Inject] private BedManager _bedManager;

        public event Action EndOfTreatment = delegate { };

        public void StartPatientTreatment()
        {
            _bedManager.MakeBedsWithPatientInteractable();
        }

    }
}
        // private Dictionary<BedSpotView, Patient> _beds = new();
        // public void StartPatientTreatment()
        // {
        //     foreach (var bed in _beds)
        //     {
        //         if (bed.Value != null)
        //         {
        //             bed.Key.TurnOnInteract();
        //         }
        //     }
        // }
