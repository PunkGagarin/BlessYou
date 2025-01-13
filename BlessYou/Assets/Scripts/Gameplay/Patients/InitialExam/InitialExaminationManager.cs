using System;
using Gameplay.Treatment.Beds;
using UnityEngine;
using Zenject;

namespace Gameplay.Patients.InitialExam
{
    public class InitialExaminationManager : MonoBehaviour
    {
        [Inject] private InitialExaminationUI _ui;
        [Inject] private BedManager _bedManager;

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
            Debug.Log("Мы выгнали пациента");
            _ui.Hide();
            OnPatientDistributed.Invoke();
        }

        private void QuickHealPatient()
        {
            throw new NotImplementedException();
            OnPatientDistributed.Invoke();
        }

        private void HideView()
        {
            _ui.Hide();
        }

        public void StartExaminationFor(Patient patient)
        {
            _currentPatient = patient;

            // SetQuickHealButtonStatus
            // SetEventButtonStatus

            bool acceptButtonActive = GetAcceptButtonStatus();
            bool quickHealButtonActive = GetQuickHealButtonStatus();

            _ui.SetAcceptButtonStatus(acceptButtonActive);
            _ui.SetQuickHealButtonStatus(quickHealButtonActive);

            _ui.ShowPatient(patient);
        }


        private bool GetAcceptButtonStatus()
        {
            return _bedManager.HasFreeBed();
        }

        private bool GetQuickHealButtonStatus()
        {
            //todo: implement me
            return false;
        }
    }
}