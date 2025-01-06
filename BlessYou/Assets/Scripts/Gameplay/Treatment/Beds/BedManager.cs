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

        //todo: move to Init method if have conflics with awake-start
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
            }
        }

        public void LayDownPatientToFirstFreeBed(Patient patient)
        {
            if (TryGetFreeBed(out BedInfo bed))
            {
                bed.Patient = patient;
                var bedView = _beds.First(bedPair => bedPair.Value == bed).Key;
                bedView.SetPatient(patient);
            }
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
            foreach (var (view, bedInfo) in _beds)
            {
                if(bedInfo.HasPatient)
                    view.TurnOnInteract();
            }
        }

        public void CleanBeds()
        {
            foreach (var (view, bed) in _beds.Where(bed => bed.Value.IsUnlocked))
            {
                bed.Patient = null;
            }
        }
    }
}