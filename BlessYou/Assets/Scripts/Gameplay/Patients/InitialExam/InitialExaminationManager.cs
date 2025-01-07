using System;
using Gameplay.Treatment.Beds;
using UnityEngine;
using Zenject;

namespace Gameplay.Patients.InitialExam
{
    public class InitialExaminationManager : MonoBehaviour
    {
        [Inject] private InitialExaminationView _view;
        [Inject] private BedManager _bedManager;

        private Patient _currentPatient;

        public event Action OnPatientDistributed = delegate { };

        private void Awake()
        {
            _view.AcceptButton.onClick.AddListener(LayDownPatient);
            _view.RejectButton.onClick.AddListener(KickOutPatient);
            _view.QuickHealButton.onClick.AddListener(QuickHealPatient);
        }

        private void OnDestroy()
        {
            _view.AcceptButton.onClick.RemoveListener(LayDownPatient);
            _view.RejectButton.onClick.RemoveListener(KickOutPatient);
            _view.QuickHealButton.onClick.RemoveListener(QuickHealPatient); 
        }

        private void LayDownPatient()
        {
            _bedManager.LayDownPatientToFirstFreeBed(_currentPatient);
            _view.Hide();
            OnPatientDistributed.Invoke();
        }

        private void KickOutPatient()
        {
            Debug.Log("Мы выгнали пациента");
            _view.Hide();
            OnPatientDistributed.Invoke();
        }

        private void QuickHealPatient()
        {
            throw new NotImplementedException();
            OnPatientDistributed.Invoke();
        }

        public void StartExaminationFor(Patient patient)
        {

            _currentPatient = patient;
            
            // SetQuickHealButtonStatus
            // SetEventButtonStatus

            bool acceptButtonActive = GetAcceptButtonStatus();
            bool quickHealButtonActive = GetQuickHealButtonStatus();
            
            _view.SetAcceptButtonStatus(acceptButtonActive);
            _view.SetQuickHealButtonStatus(quickHealButtonActive);
            
            _view.ShowPatient(patient);
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