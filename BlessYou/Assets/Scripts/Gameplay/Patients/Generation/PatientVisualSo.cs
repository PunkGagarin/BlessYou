using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Patients.Generation
{
    
    // [CreateAssetMenu(menuName = "Gameplay/Settings/PatientVisualRepository", fileName = "PatientVisualRepository")]
    public class PatientVisualRepositorySo : ScriptableObject
    {

        [SerializeField]
        private List<CustomKeyValue<Bodytype, Sprite>> _bodyTypes;

        [SerializeField]
        private List<CustomKeyValue<Bodytype, List<CustomKeyValue<PatientVisualType, List<Sprite>>>>> _parts;
    }

}