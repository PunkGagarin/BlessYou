using Gameplay.Patients.Diseases;

namespace Gameplay.Patients.UI
{
    public class PatientTreatmentInfoUI : PatientInfoUI
    {

        protected override void SetDiseaseInfo(DiseaseSO patientDisease)
        {
            DiseaseInfo.text = patientDisease.Name;
        }

    }
}