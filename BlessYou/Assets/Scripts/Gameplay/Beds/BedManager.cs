using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Beds;
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
        public event Action<Patient, BedSpotView, BedInfo> OnBedTimerEnds = delegate { };

        private void Start()
        {
            InitBeds();
        }

        private void InitBeds()
        {
            int unlockedBeds = _bedSettings.InitialUnlockedBeds;
            for (int index = 0; index < _bedViews.Count; index++)
            {
                var bedView = _bedViews[index];
                var bedInfo = new BedInfo();
                _beds[bedView] = bedInfo;

                if (index < unlockedBeds)
                {
                    bedView.Unlock();
                    _beds[bedView].IsUnlocked = true;
                }
                else
                {
                    bedView.Lock();
                }

                bedView.OnClicked += bedViewOnOnBedClicked(bedView);
                bedView.OnTimerEnds += EndTimerForBed(bedView, bedInfo);
            }
        }

        private Action EndTimerForBed(BedSpotView bedView, BedInfo bedInfo)
        {
            return () => OnBedTimerEnds.Invoke(bedInfo.Patient, bedView, bedInfo);
        }

        private void OnDestroy()
        {
            foreach (var bedView in _beds.Keys)
            {
                bedView.OnClicked -= bedViewOnOnBedClicked(bedView);
                bedView.OnTimerEnds -= EndTimerForBed(bedView, _beds[bedView]);
            }
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
                    bed.CurrentTreatmentType = TreatmentType.View;
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

        public bool HasNoPatientsLeft()
        {
            return !_beds.Any( bed => bed.Value.HasPatient);
        }

        public List<Patient> GetAllPatientsInBeds()
        {
            return _beds
                .Where(bed => bed.Value.HasPatient)
                .Select(bed => bed.Value.Patient)
                .ToList();
        }

        public void UnlockNewBed()
        {
            var (bedViews, bedInfo) = _beds.FirstOrDefault(
                bed => !bed.Value.IsUnlocked);

            bedViews.Unlock();
            bedInfo.IsUnlocked = true;
        }

        public bool HasBedsToUnlock()
        {
            return _beds.Any(bed => !bed.Value.IsUnlocked);
        }

        public void CleanBed(BedSpotView view)
        {
            var bed = _beds.FirstOrDefault(bed => bed.Value.HasPatient);

            bed.Value.Patient = null;
            view.CleanFromPatient();
        }

        public void StartHealFor(BedSpotView bed)
        {
            BedInfo bedInfo = _beds[bed];
            bed.TurnOffInteract();
            bed.SetTimer(bedInfo.Patient.Disease.HealInfo.HealTime);
            bedInfo.CurrentTreatmentType = TreatmentType.Healing;
        }
    }
}