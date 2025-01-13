﻿using Gameplay.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Treatment
{
    public class PatientTreatmentView : ContentUI
    {

        [field: SerializeField]
        public Button HealButton { get; private set; }

        public void ShowPatientInfo(Patient patient)
        {
            Show();
        }
    }
}