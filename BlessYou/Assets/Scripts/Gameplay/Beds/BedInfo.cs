using System;

namespace Gameplay.Treatment.Beds
{
    [Serializable]
    public class BedInfo
    {
        public bool IsUnlocked { get; set; }
        public Patient Patient { get; set; }
        public bool HasPatient => Patient != null;
        
        public TreatmentType CurrentTreatmentType { get; set; } = TreatmentType.View;
    }

}