using System;
using Gameplay.Patients.Generation;
using UnityEngine;
using Zenject;

namespace Gameplay.Treatment
{
    public class GlossaryManager : MonoBehaviour
    {
        [Inject] private GlossaryUI _glossaryUI;
        [Inject] private PatientGenerationRepository _repo;

        private void Start()
        {
            _glossaryUI.SetDiseases(_repo.GetAllDiseases());
        }
    }
}