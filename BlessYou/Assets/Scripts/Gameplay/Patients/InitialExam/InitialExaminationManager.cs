using Gameplay.Patients;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class InitialExaminationManager : MonoBehaviour
    {
        [Inject] private InitialExaminationView _view;

        public void StartExaminationFor(Patient patient)
        {
            Debug.Log("Showing patient info");
            _view.ShowPatient(patient);
        }
    }
}