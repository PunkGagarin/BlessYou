using System.Collections.Generic;

namespace Gameplay.DayResults
{
    public class TreatmentResultInfo
    {
        public List<Patient> HealedPatientsList { get; set; } = new();
        public List<Patient> DeadPatientsList { get; set; } = new();
        public int HealedPatients { get; set; }
        public int DeadPatients { get; set; }
        public int GoldDifference { get; set; }
    }
}