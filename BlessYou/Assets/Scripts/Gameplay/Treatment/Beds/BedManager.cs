using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay.Treatment.Beds
{
    public class BedManager : MonoBehaviour
    {

        [Inject] private BedSettings _bedSettings;

        [SerializeField]
        private List<BedSpotView> _bedViews;

        private readonly Dictionary<BedSpotView, BedInfo> _beds = new();

        public event Action<Patient, BedSpotView> OnBedWithPatientInteracted = delegate { };

        private void Awake()
        {
            InitBeds();
        }

        private void InitBeds()
        {
            int unlockedBeds = _bedSettings.InitialUnlockedBeds;
            for (int index = 0; index < _bedViews.Count; index++)
            {
                var bedView = _bedViews[index];
                _beds[bedView] = new BedInfo();

                if (index < unlockedBeds)
                {
                    bedView.Unlock();
                    _beds[bedView].IsUnlocked = true;
                }
                else
                {
                    bedView.Lock();
                }

                bedView.OnBedClicked += bedViewOnOnBedClicked(bedView);
            }
        }

        private void OnDestroy()
        {
            foreach (var bedView in _beds.Keys)
                bedView.OnBedClicked -= bedViewOnOnBedClicked(bedView);
        }

        private Action bedViewOnOnBedClicked(BedSpotView bedView)
        {
            return () => OnBedInterracted(bedView);
        }

        private void OnBedInterracted(BedSpotView bedView)
        {
            OnBedWithPatientInteracted.Invoke(_beds[bedView].Patient, bedView);
        }

        public void LayDownPatientToFirstFreeBed(Patient patient)
        {
            foreach (var (view, bed) in _beds.Where(beds => beds.Value.IsUnlocked))
            {
                if (!bed.HasPatient)
                {
                    bed.Patient = patient;
                    view.SetPatient(patient);
                    return;
                }
            }
            Debug.LogError("trying to set patient while we have no free beds");
        }

        private bool TryGetFreeBed(out BedInfo bed)
        {
            bed = _beds
                .FirstOrDefault(bed => bed.Value.IsUnlocked && !bed.Value.HasPatient)
                .Value;

            return bed != null;
        }

        public bool HasFreeBed()
        {
            return TryGetFreeBed(out _);
        }

        public void MakeBedsWithPatientInteractable()
        {
            Debug.Log("making beds interactable");
            foreach (var (view, bedInfo) in _beds)
            {
                if (bedInfo.HasPatient)
                    view.TurnOnInteract();
            }
        }

        public void CleanBeds()
        {
            foreach (var (view, bed) in _beds.Where(bed => bed.Value.HasPatient))
            {
                if (bed.Patient.IsDead || bed.Patient.IsHealed)
                {
                    bed.Patient = null;
                    view.CleanFromPatient();
                }
            }
        }

        public bool AllPatientsHealed()
        {
            return _beds.Where(bed => bed.Value.HasPatient)
                .All(bed => bed.Value.Patient.HasTreatment);
        }

        public List<Patient> GetAllPatientsInBeds()
        {
            return _beds
                .Where(bed => bed.Value.HasPatient)
                .Select(bed => bed.Value.Patient)
                .ToList();
        }
    }
}