using System;
using Gameplay.Base;
using Gameplay.Patients;
using UnityEngine;

namespace Gameplay.Beds
{
    public class BedSpotView : ClickableView
    {

        [SerializeField]
        private SpriteRenderer _unlockedBedSprite;

        [SerializeField]
        private SpriteRenderer _lockedBedSprite;

        [SerializeField]
        private SpriteRenderer _patientSprite;

        [SerializeField]
        private PatientTimerUI _timerUI;
    
        public event Action OnTimerEnds = delegate { };

        private void Awake()
        {
            _timerUI.OnTimerEnds += InvokeOnTimerEnds;
        }

        private void InvokeOnTimerEnds()
        {
            OnTimerEnds.Invoke();
        }

        private void OnDestroy()
        {
            _timerUI.OnTimerEnds -= InvokeOnTimerEnds;
        }

        public void TurnOnInteract()
        {
            _collider2D.enabled = true;
        }

        public void TurnOffInteract()
        {
            _collider2D.enabled = false;
        }

        public void Unlock()
        {
            _unlockedBedSprite.gameObject.SetActive(true);
            _lockedBedSprite.gameObject.SetActive(false);
            _patientSprite.gameObject.SetActive(false);
            TurnOffInteract();
        }

        public void Lock()
        {
            _unlockedBedSprite.gameObject.SetActive(false);
            _lockedBedSprite.gameObject.SetActive(true);
            _patientSprite.gameObject.SetActive(false);
            TurnOffInteract();
        }

        public void SetPatient(Patient patient)
        {
            _patientSprite.gameObject.SetActive(true);
            _timerUI.Show();
            SetTimer(patient.Disease.HealInfo.TreatmentTime);
            TurnOnInteract();
        }

        public void SetTimer(float time)
        {
            _timerUI.SetTimer(time);
        }

        public void CleanFromPatient()
        {
            _patientSprite.gameObject.SetActive(false);
            _timerUI.Hide();
            TurnOffInteract();
        }
    }
}