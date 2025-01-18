using System;
using Audio;
using Gameplay.DayResults;
using Gameplay.Inventory;
using Gameplay.Patients.Diseases;
using Gameplay.Patients.Generation;
using Gameplay.Results;
using Gameplay.Treatment.Beds;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Gameplay.Patients.InitialExam
{
    public class InitialExaminationManager : MonoBehaviour
    {
        [Inject] private InitialExaminationUI _ui;
        [Inject] private BedManager _bedManager;
        [Inject] private MedicamentaryManager _medicamentaryManager;
        [Inject] private InstrumentaryManager _instrumentaryManager;
        [Inject] private TreatmentResultManager _resultManager;
        [Inject] private SoundManager _soundManager;

        private Patient _currentPatient;

        public event Action OnPatientDistributed = delegate { };

        private void Awake()
        {
            _ui.AcceptButton.onClick.AddListener(LayDownPatient);
            _ui.RejectButton.onClick.AddListener(KickOutPatient);
            _ui.QuickHealButton.onClick.AddListener(QuickHealPatient);
            _ui.CloseButton.onClick.AddListener(HideView);
        }

        private void OnDestroy()
        {
            _ui.AcceptButton.onClick.RemoveListener(LayDownPatient);
            _ui.RejectButton.onClick.RemoveListener(KickOutPatient);
            _ui.QuickHealButton.onClick.RemoveListener(QuickHealPatient);
            _ui.QuickHealButton.onClick.RemoveListener(HideView);
        }

        private void LayDownPatient()
        {
            _bedManager.LayDownPatientToFirstFreeBed(_currentPatient);
            _ui.Hide();
            OnPatientDistributed.Invoke();
        }

        public void KickOutPatient()
        {
            _ui.Hide();
            _resultManager.SetKickedOutPatient(_currentPatient);
            OnPatientDistributed.Invoke();
        }

        private void QuickHealPatient()
        {
            _medicamentaryManager.Spend(_currentPatient.Disease.HealInfo.MedicamentType);
            _ui.Hide();
            _resultManager.SetHealedPatient(_currentPatient);
            OnPatientDistributed.Invoke();
        }

        private void HideView()
        {
            _ui.Hide();
        }

        public void StartExaminationFor(Patient patient)
        {
            _currentPatient = patient;

            bool acceptButtonActive = GetAcceptButtonStatus();
            bool quickHealButtonActive = GetQuickHealButtonStatus(patient.Disease);

            _ui.SetAcceptButtonStatus(acceptButtonActive);
            _ui.SetQuickHealButtonStatus(quickHealButtonActive, 
                patient.Disease.HealInfo.MedicamentType.ToString(), patient.Disease.HeavinessType);

            Show(patient);
        }

        private void Show(Patient patient)
        {
            _soundManager.PlayRandomSoundByType(GameAudioType.Caught, Vector3.zero);
            _ui.ShowPatient(patient);
        }

        private bool GetAcceptButtonStatus()
        {
            return _bedManager.HasFreeBed();
        }

        private bool GetQuickHealButtonStatus(DiseaseSO disease)
        {
            bool hasMed = _medicamentaryManager.HasItem(disease.HealInfo.MedicamentType);
            bool hasInstr = _instrumentaryManager.HasItem(disease.HealInfo.InstrumentType);
            bool isLight = disease.HeavinessType == DiseaseHeavinessType.Light;

            return hasMed && hasInstr && isLight;
        }
    }
}