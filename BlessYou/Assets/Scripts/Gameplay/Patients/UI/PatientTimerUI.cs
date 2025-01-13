using System;
using Gameplay.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Patients
{
    public class PatientTimerUI : ContentUI
    {
        [SerializeField]
        private Color _defaultColor;
        
        [SerializeField]
        private Color _lowTimerColor;

        [SerializeField]
        private Image _foregroundImage;

        private float _maxTimer;
        private float _currentTimer;
        private bool _isTimerActive;

        public event Action OnTimerEnds = delegate { };

        public void SetTimer(float maxTimer)
        {
            _maxTimer = maxTimer;
            _currentTimer = maxTimer;
            _foregroundImage.fillAmount = 1f;
            _foregroundImage.color = _defaultColor;
            _isTimerActive = true;
        }

        private void Update()
        {
            if(!_isTimerActive)
                return;
            
            _currentTimer -= Time.deltaTime;
            _foregroundImage.fillAmount = _currentTimer / _maxTimer;
            _foregroundImage.color = _currentTimer < _maxTimer / 3 ? _lowTimerColor : _defaultColor;

            if (_currentTimer <= 0)
            {
                _isTimerActive = false;
                OnTimerEnds();
            }
        }
    }
}